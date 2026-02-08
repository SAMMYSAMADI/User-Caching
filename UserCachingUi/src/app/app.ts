import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { UserService } from './user/user.service';
import { User } from './user/user';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  users: User[] = [];
  showTable = false;

  user: User = {
    id: 0,
    name: '',
    username: '',
    email: ''
  };

  constructor(private service: UserService) {}

  showData() {
    this.service.getUsers().subscribe(res => {
      this.users = res;
      this.showTable = true;
    });
  }

  edit(u: User) {
    this.user = { ...u };
  }

  save() {
    //NULL VALIDATION
    if (!this.user.id || !this.user.name.trim() || !this.user.username.trim() || !this.user.email.trim()) {
      alert('All fields are required ❌');
      return;
    }

    //EMAIL FORMAT VALIDATION
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(this.user.email)) {
      alert('Invalid email format ❌');
      return;
    }

    const exists = this.users.find(u => u.id === this.user.id);

    if (exists) {
      // UPDATE
      this.service.updateUser(this.user).subscribe(() => {
        alert('User updated successfully ✅');
        this.showData();
        this.clear();
      });
    } else {
      // INSERT
      this.service.addUser(this.user).subscribe(() => {
        alert('User saved successfully ✅');
        this.showData();
        this.clear();
      });
    }
  }

  delete(id: number) {
    if (confirm('Are you sure you want to delete this user?')) {
      this.service.deleteUser(id).subscribe(() => {
        alert('User deleted successfully 🗑️');
        this.showData();
      });
    }
  }

  clear() {
    this.user = {
      id: 0,
      name: '',
      username: '',
      email: ''
    };
  }
}

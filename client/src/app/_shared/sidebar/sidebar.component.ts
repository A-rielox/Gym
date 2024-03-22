import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';

@Component({
   selector: 'app-sidebar',
   templateUrl: './sidebar.component.html',
   styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnInit {
   loginForm: FormGroup = new FormGroup({});

   constructor(
      private fb: FormBuilder,
      private accountService: AccountService,
      private router: Router
   ) {}

   ngOnInit(): void {
      this.initializeForm();
   }

   initializeForm() {
      this.loginForm = this.fb.group({
         userName: ['', Validators.required],
         password: ['', [Validators.required]],
      });
   }

   login() {
      console.log('login-----', this.loginForm.value);

      // this.accountService.login(this.loginForm.value).subscribe({
      //    next: (res) => {
      //       this.router.navigateByUrl('/clases');
      //    },
      //    error: (err) => console.log(err),
      // });
   }

   //#region htmlClasses
   favoritosMainLinkClass() {
      return 'flex align-items-center cursor-pointer p-3 text-700 border-2 border-transparent hover:border-300 transition-duration-150 transition-colors';
   }
   applicationsLinkClass() {
      return 'flex align-items-center cursor-pointer p-3 border-2 border-transparent hover:border-300 text-700 transition-duration-150 transition-colors';
   }
   topMenuInboxNotification() {
      return 'flex p-3 lg:px-3 lg:py-2 align-items-center text-600 hover:text-900 hover:surface-100 font-medium border-round cursor-pointer transition-duration-150 transition-colors';
   }
   topMenuOthers() {
      return 'flex p-3 lg:px-3 lg:py-2 align-items-center text-600 hover:text-900 hover:surface-200 font-medium border-round cursor-pointer transition-duration-150 transition-colors';
   }
   dropDownUlClass() {
      return 'list-none py-0 pl-3 pr-0 m-0 hidden overflow-y-hidden transition-all transition-duration-400 transition-ease-in-out';
   }
   //#endregion htmlClasses
}

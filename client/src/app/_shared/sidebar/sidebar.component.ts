import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { AccountService } from 'src/app/_services/account.service';

@Component({
   selector: 'app-sidebar',
   templateUrl: './sidebar.component.html',
   styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnInit {
   loginForm: FormGroup = new FormGroup({});
   items: MenuItem[] = [];

   constructor(
      private fb: FormBuilder,
      public accountService: AccountService,
      private router: Router
   ) {}

   ngOnInit(): void {
      this.initializeForm();
      this.setItems();
   }

   initializeForm() {
      this.loginForm = this.fb.group({
         userName: ['lisa', Validators.required],
         password: ['P@ssword1', [Validators.required]],
      });
   }

   login() {
      console.log(this.loginForm.value, 'xxxxxxxxxxxxxxx');
      this.accountService.login(this.loginForm.value).subscribe({
         next: (res) => {
            this.router.navigateByUrl('/clases');
         },
         error: (err) => console.log(err),
      });
   }

   logout() {
      this.accountService.logout();

      this.router.navigateByUrl('/');
   }

   setItems() {
      this.items = [
         {
            label: 'Editar Perfil',
            icon: 'pi pi-cog',
            routerLink: ['/members/edit'],
         },
         {
            label: 'Salir',
            icon: 'pi pi-sign-out',
            command: () => {
               this.logout();
            },
         },
      ];
   }

   //#region htmlClasses
   sideNavLinkClass() {
      return 'flex align-items-center cursor-pointer p-3 text-700 border-2 border-transparent hover:surface-hover transition-duration-150 transition-colors';
   }
   sideNavFooterIconsClass() {
      return 'cursor-pointer inline-flex align-items-center justify-content-center hover:surface-100 transition-colors transition-duration-150 w-3rem h-3rem border-circle';
   }
   avatarClass() {
      return 'flex h-full px-6 p-3 lg:px-3 lg:py-2 align-items-center text-600 hover:text-900 border-left-2 lg:border-bottom-2 lg:border-left-none border-transparent hover:border-primary font-medium cursor-pointer transition-colors transition-duration-150';
   }
   //#endregion htmlClasses
}

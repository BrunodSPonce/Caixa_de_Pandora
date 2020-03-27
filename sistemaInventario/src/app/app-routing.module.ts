import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ErrorComponent } from './content/error/error.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './content/home/home.component';
import { EditarComponent } from './content/editar/editar.component';
import { CadastrarComponent } from './content/cadastrar/cadastrar.component';
import { ContentComponent } from './content/content.component';
import { ContentResolverGuard } from './guards/content.resolver.guards';


const routes: Routes = [
  {
    path: 'login', component: LoginComponent
  },
  {
    path: '', component: ContentComponent, canActivate: [AuthGuard],
    children: [
      { path: 'home', component: HomeComponent, canActivateChild: [AuthGuard]},
      { 
        path: 'editar/:id', 
        component: EditarComponent, canActivateChild: [AuthGuard], 
        resolve: { 
          servidor: ContentResolverGuard 
        }
      },
      //{ path: 'editar', component: EditarComponent },
      { path: 'cadastrar', component: CadastrarComponent, canActivateChild: [AuthGuard]},
      { path: '**', component: ErrorComponent, canActivateChild: [AuthGuard] }
    ]
  },

  {
    path: '', redirectTo: '/login', pathMatch: 'full'
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

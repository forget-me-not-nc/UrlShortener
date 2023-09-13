import { Component } from "@angular/core";
import { AboutService } from "../services/about.service";
import { Roles } from "../models/roles";
import { MyRoleService } from "../services/role.service";
import { AboutModel } from "../models/about.model";

@Component({
  selector: 'app-about-page',
  templateUrl: './about-page.component.html',
  styleUrls: ['./about-page.component.css']
})
export class AboutPageComponent {
  content: string;
  public Roles = Roles;

  constructor(private aboutService: AboutService,
              private roleService: MyRoleService) {}

  ngOnInit(): void {
    this.aboutService.getAboutContent().subscribe((data) => {
      this.content = data.content;
    });
  }

  isAdmin(): boolean {
    return this.roleService.hasRole(Roles.ADMIN);
  }

  saveDescription() {
    const body: AboutModel = {
      content: this.content,
    };
    this.aboutService.storeAboutContent(body).subscribe();
  }
}
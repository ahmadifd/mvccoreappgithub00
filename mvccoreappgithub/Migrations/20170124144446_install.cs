using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mvccoreappgithub.Migrations
{
    public partial class install : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "People",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepeatEmail",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "People",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "People",
                type: "VarChar(16)",
                maxLength: 5,
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllPeople",
                table: "People",
                columns: new[] { "ID", "JobID" });

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "People",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "People",
                newName: "PersonID");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "AllPeople");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AllPeople",
                table: "AllPeople");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "AllPeople");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AllPeople");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AllPeople");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AllPeople");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AllPeople");

            migrationBuilder.DropColumn(
                name: "RepeatEmail",
                table: "AllPeople");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "AllPeople");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AllPeople");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AllPeople",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "AllPeople",
                column: "PersonID");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AllPeople",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "AllPeople",
                newName: "ID");

            migrationBuilder.RenameTable(
                name: "AllPeople",
                newName: "People");
        }
    }
}

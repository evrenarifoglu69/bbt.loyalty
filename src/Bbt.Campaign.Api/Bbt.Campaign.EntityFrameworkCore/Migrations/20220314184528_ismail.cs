using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bbt.Campaign.EntityFrameworkCore.Migrations
{
    public partial class ismail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_ActionOptions_ActionOptionId",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_ActionOptionId",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "ActionOptionId",
                table: "Campaigns");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "CampaignAchievements",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxUtilization",
                table: "CampaignAchievements",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxAmount",
                table: "CampaignAchievements",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "CampaignAchievements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CampaignAchievements",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "AchievementTypeId",
                table: "CampaignAchievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionOptionId",
                table: "CampaignAchievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "CampaignAchievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "CampaignAchievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionTr",
                table: "CampaignAchievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "CampaignAchievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleTr",
                table: "CampaignAchievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "CampaignAchievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AchievementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetGroupLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TargetGroupId = table.Column<int>(type: "int", nullable: false),
                    TargetId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetGroupLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetGroupLines_TargetGroups_TargetGroupId",
                        column: x => x.TargetGroupId,
                        principalTable: "TargetGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TargetGroupLines_Targets_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Targets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AchievementFrequencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "AchievementFrequencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "AchievementFrequencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.InsertData(
                table: "AchievementTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7464), false, null, null, "Mevduat" },
                    { 2, "1", new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7530), false, null, null, "Kredi" },
                    { 3, "1", new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7565), false, null, null, "Cashback" }
                });

            migrationBuilder.UpdateData(
                table: "ActionOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreatedOn" },
                values: new object[] { "1", new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7760) });

            migrationBuilder.InsertData(
                table: "ActionOptions",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 2, "2", "1", new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7822), false, null, null, "Fatura Cashback" });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(5992));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8138));

            migrationBuilder.UpdateData(
                table: "CampaignStartTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "CampaignStartTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7152));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "JoinTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "JoinTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "JoinTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "JoinTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "JoinTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "TargetOperations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "TargetOperations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "TargetOperations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "TargetOperations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "TargetSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "TargetSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "TargetViewTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "TargetViewTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "TriggerTimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "TriggerTimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "VerificationTimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "VerificationTimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "ViewOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "ViewOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "ViewOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 14, 21, 45, 26, 571, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.CreateIndex(
                name: "IX_CampaignAchievements_AchievementTypeId",
                table: "CampaignAchievements",
                column: "AchievementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignAchievements_ActionOptionId",
                table: "CampaignAchievements",
                column: "ActionOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignAchievements_CampaignId",
                table: "CampaignAchievements",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetGroupLines_TargetGroupId",
                table: "TargetGroupLines",
                column: "TargetGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetGroupLines_TargetId",
                table: "TargetGroupLines",
                column: "TargetId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignAchievements_AchievementTypes_AchievementTypeId",
                table: "CampaignAchievements",
                column: "AchievementTypeId",
                principalTable: "AchievementTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignAchievements_ActionOptions_ActionOptionId",
                table: "CampaignAchievements",
                column: "ActionOptionId",
                principalTable: "ActionOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignAchievements_Campaigns_CampaignId",
                table: "CampaignAchievements",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignAchievements_AchievementTypes_AchievementTypeId",
                table: "CampaignAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignAchievements_ActionOptions_ActionOptionId",
                table: "CampaignAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignAchievements_Campaigns_CampaignId",
                table: "CampaignAchievements");

            migrationBuilder.DropTable(
                name: "AchievementTypes");

            migrationBuilder.DropTable(
                name: "TargetGroupLines");

            migrationBuilder.DropTable(
                name: "TargetGroups");

            migrationBuilder.DropIndex(
                name: "IX_CampaignAchievements_AchievementTypeId",
                table: "CampaignAchievements");

            migrationBuilder.DropIndex(
                name: "IX_CampaignAchievements_ActionOptionId",
                table: "CampaignAchievements");

            migrationBuilder.DropIndex(
                name: "IX_CampaignAchievements_CampaignId",
                table: "CampaignAchievements");

            migrationBuilder.DeleteData(
                table: "ActionOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AchievementTypeId",
                table: "CampaignAchievements");

            migrationBuilder.DropColumn(
                name: "ActionOptionId",
                table: "CampaignAchievements");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "CampaignAchievements");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "CampaignAchievements");

            migrationBuilder.DropColumn(
                name: "DescriptionTr",
                table: "CampaignAchievements");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "CampaignAchievements");

            migrationBuilder.DropColumn(
                name: "TitleTr",
                table: "CampaignAchievements");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CampaignAchievements");

            migrationBuilder.AddColumn<int>(
                name: "ActionOptionId",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "CampaignAchievements",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxUtilization",
                table: "CampaignAchievements",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxAmount",
                table: "CampaignAchievements",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                table: "CampaignAchievements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CampaignAchievements",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AchievementFrequencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "AchievementFrequencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "AchievementFrequencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "ActionOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreatedOn" },
                values: new object[] { "SK", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8224) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "BusinessLines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8481));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "CampaignChannels",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "CampaignStartTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "CampaignStartTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8651));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "JoinTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "JoinTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "JoinTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "JoinTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "JoinTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8105));

            migrationBuilder.UpdateData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "TargetOperations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "TargetOperations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "TargetOperations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "TargetOperations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "TargetSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "TargetSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "TargetViewTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "TargetViewTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "TriggerTimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "TriggerTimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "VerificationTimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "VerificationTimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "ViewOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "ViewOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "ViewOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_ActionOptionId",
                table: "Campaigns",
                column: "ActionOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_ActionOptions_ActionOptionId",
                table: "Campaigns",
                column: "ActionOptionId",
                principalTable: "ActionOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

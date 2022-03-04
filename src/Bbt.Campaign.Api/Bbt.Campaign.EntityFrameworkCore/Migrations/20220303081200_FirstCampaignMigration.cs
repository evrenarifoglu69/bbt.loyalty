using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bbt.Campaign.EntityFrameworkCore.Migrations
{
    public partial class FirstCampaignMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AchievementFrequencies",
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
                    table.PrimaryKey("PK_AchievementFrequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessLines",
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
                    table.PrimaryKey("PK_BusinessLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignChannels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignChannels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignStartTerms",
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
                    table.PrimaryKey("PK_CampaignStartTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
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
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JoinTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetOperations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetSources",
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
                    table.PrimaryKey("PK_TargetSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetViewTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetViewTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TriggerTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerificationTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViewOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignAchievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignChannelId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxUtilization = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignAchievements_CampaignChannels_CampaignChannelId",
                        column: x => x.CampaignChannelId,
                        principalTable: "CampaignChannels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignAchievements_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TargetDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TargetId = table.Column<int>(type: "int", nullable: false),
                    TargetSourceId = table.Column<int>(type: "int", nullable: false),
                    TriggerTimeId = table.Column<int>(type: "int", nullable: true),
                    TargetViewTypeId = table.Column<int>(type: "int", nullable: false),
                    VerificationTimeId = table.Column<int>(type: "int", nullable: true),
                    FlowName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetDetailEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetDetailTr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionTr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfTransaction = table.Column<int>(type: "int", nullable: false),
                    FlowFrequency = table.Column<int>(type: "int", nullable: false),
                    AdditionalFlowTime = table.Column<int>(type: "int", nullable: false),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetDetails_Targets_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Targets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TargetDetails_TargetSources_TargetSourceId",
                        column: x => x.TargetSourceId,
                        principalTable: "TargetSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TargetDetails_TargetViewTypes_TargetViewTypeId",
                        column: x => x.TargetViewTypeId,
                        principalTable: "TargetViewTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TargetDetails_TriggerTimes_TriggerTimeId",
                        column: x => x.TriggerTimeId,
                        principalTable: "TriggerTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TargetDetails_VerificationTimes_VerificationTimeId",
                        column: x => x.VerificationTimeId,
                        principalTable: "VerificationTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescriptionTr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleTr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    MaxNumberOfUser = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    ViewOptionId = table.Column<int>(type: "int", nullable: false),
                    ActionOptionId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsBundle = table.Column<bool>(type: "bit", nullable: false),
                    IsContract = table.Column<bool>(type: "bit", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    ProgramTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_ActionOptions_ActionOptionId",
                        column: x => x.ActionOptionId,
                        principalTable: "ActionOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaigns_ProgramTypes_ProgramTypeId",
                        column: x => x.ProgramTypeId,
                        principalTable: "ProgramTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaigns_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaigns_ViewOptions_ViewOptionId",
                        column: x => x.ViewOptionId,
                        principalTable: "ViewOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    CampaignListImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampaignDetailImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SummaryTr = table.Column<string>(type: "ntext", nullable: false),
                    SummaryEn = table.Column<string>(type: "ntext", nullable: false),
                    ContentTr = table.Column<string>(type: "ntext", nullable: false),
                    ContentEn = table.Column<string>(type: "ntext", nullable: false),
                    DetailTr = table.Column<string>(type: "ntext", nullable: false),
                    DetailEn = table.Column<string>(type: "ntext", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignDetails_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignDocuments_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    JoinTypeId = table.Column<int>(type: "int", nullable: false),
                    CampaignStartTermId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignRules_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignRules_CampaignStartTerms_CampaignStartTermId",
                        column: x => x.CampaignStartTermId,
                        principalTable: "CampaignStartTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignRules_JoinTypes_JoinTypeId",
                        column: x => x.JoinTypeId,
                        principalTable: "JoinTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignTargets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    TargetOperationId = table.Column<int>(type: "int", nullable: false),
                    TargetDefinitionId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignTargets_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignTargets_TargetDefinitions_TargetDefinitionId",
                        column: x => x.TargetDefinitionId,
                        principalTable: "TargetDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignTargets_TargetOperations_TargetOperationId",
                        column: x => x.TargetOperationId,
                        principalTable: "TargetOperations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignTopLimits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    AchievementFrequencyId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    MaxTopLimitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxTopLimitRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxTopLimitUtilization = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignTopLimits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignTopLimits_AchievementFrequencies_AchievementFrequencyId",
                        column: x => x.AchievementFrequencyId,
                        principalTable: "AchievementFrequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignTopLimits_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignTopLimits_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignRuleBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignRuleId = table.Column<int>(type: "int", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRuleBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignRuleBranches_CampaignRules_CampaignRuleId",
                        column: x => x.CampaignRuleId,
                        principalTable: "CampaignRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignRuleBusinesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignRuleId = table.Column<int>(type: "int", nullable: false),
                    BusinessLineId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRuleBusinesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignRuleBusinesses_BusinessLines_BusinessLineId",
                        column: x => x.BusinessLineId,
                        principalTable: "BusinessLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignRuleBusinesses_CampaignRules_CampaignRuleId",
                        column: x => x.CampaignRuleId,
                        principalTable: "CampaignRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignRuleCustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignRuleId = table.Column<int>(type: "int", nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRuleCustomerTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignRuleCustomerTypes_CampaignRules_CampaignRuleId",
                        column: x => x.CampaignRuleId,
                        principalTable: "CampaignRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignRuleCustomerTypes_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignRuleIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignRuleId = table.Column<int>(type: "int", nullable: false),
                    Identities = table.Column<string>(type: "ntext", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRuleIdentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignRuleIdentities_CampaignRules_CampaignRuleId",
                        column: x => x.CampaignRuleId,
                        principalTable: "CampaignRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AchievementFrequencies",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8623), false, null, null, "Haftalık" },
                    { 2, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8625), false, null, null, "Aylık" },
                    { 3, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8626), false, null, null, "Yıllık" }
                });

            migrationBuilder.InsertData(
                table: "ActionOptions",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 1, "SK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8224), false, null, null, "Ödeme Cashback" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "9530", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8329), false, null, null, "Merkez" },
                    { 2, "9531", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8332), false, null, null, "Çamlıca Şubesi" }
                });

            migrationBuilder.InsertData(
                table: "BusinessLines",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(5423), false, null, null, "Bireysel (B)" },
                    { 2, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(5808), false, null, null, "Ticari (T)" },
                    { 3, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(5908), false, null, null, "Dijital (X)" },
                    { 4, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(5960), false, null, null, "Ticari 1 (I)" },
                    { 5, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(6042), false, null, null, "Ticari 2 (P)" },
                    { 6, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(6146), false, null, null, "Ticari 3 (M)" },
                    { 7, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(6184), false, null, null, "Kurumsal (K)" },
                    { 8, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(6209), false, null, null, "Kurumsal 1 (A)" }
                });

            migrationBuilder.InsertData(
                table: "CampaignChannels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8459), false, null, null, "Tümü" },
                    { 2, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8478), false, null, null, "Batch" },
                    { 3, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8480), false, null, null, "Bayi" },
                    { 4, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8481), false, null, null, "Diğer" },
                    { 5, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8483), false, null, null, "İnternet" },
                    { 6, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8484), false, null, null, "Ptt" },
                    { 7, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8485), false, null, null, "Remote" },
                    { 8, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8487), false, null, null, "Sms" },
                    { 9, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8489), false, null, null, "Şube" },
                    { 10, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8491), false, null, null, "Tablet" },
                    { 11, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8493), false, null, null, "Web" },
                    { 12, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8494), false, null, null, "Web Bayi" },
                    { 13, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8496), false, null, null, "Web Mevduat" }
                });

            migrationBuilder.InsertData(
                table: "CampaignStartTerms",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8380), false, null, null, "Katılım Anında" },
                    { 2, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8383), false, null, null, "Dönem Başlangıcı" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "TRY", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8651), false, null, null, "TRY" },
                    { 2, "GBP", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8652), false, null, null, "GBP" },
                    { 3, "EUR", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8654), false, null, null, "EUR" },
                    { 4, "USD", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8655), false, null, null, "USD" }
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7290), false, null, null, "Gerçek" },
                    { 2, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7410), false, null, null, "Tüzel" },
                    { 3, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7444), false, null, null, "Ortak" },
                    { 4, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7478), false, null, null, "Reşit Olmayan" },
                    { 5, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7525), false, null, null, "Adi Ortaklık" }
                });

            migrationBuilder.InsertData(
                table: "JoinTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "SK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8273), false, null, null, "Tüm Müşteriler" },
                    { 2, "SK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8276), false, null, null, "Müşteri Özelinde" },
                    { 3, "SK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8279), false, null, null, "İş Kolu Özelinde" },
                    { 4, "SK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8283), false, null, null, "Şube Özelinde" }
                });

            migrationBuilder.InsertData(
                table: "JoinTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 5, "SK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8286), false, null, null, "Müşteri Tipi Özelinde" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "TR", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7895), false, null, null, "Türkçe" },
                    { 2, "EN", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(7900), false, null, null, "İngilizce" }
                });

            migrationBuilder.InsertData(
                table: "ProgramTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "SK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8676), false, null, null, "Sadakat" },
                    { 2, "GK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8677), false, null, null, "Kampanya" },
                    { 3, "AK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8679), false, null, null, "Kazanım" }
                });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "Akr", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8101), false, null, null, "Akaryakıt" },
                    { 2, "IT", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8105), false, null, null, "Bilişim" },
                    { 3, "Bnk", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8108), false, null, null, "Bankacılık" }
                });

            migrationBuilder.InsertData(
                table: "TargetOperations",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8414), false, null, null, "ve" },
                    { 2, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8415), false, null, null, "veya" },
                    { 3, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8417), false, null, null, "kesişim" },
                    { 4, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8418), false, null, null, "fark" }
                });

            migrationBuilder.InsertData(
                table: "TargetSources",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8809), false, null, null, "Akış" },
                    { 2, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8810), false, null, null, "Sorgu" }
                });

            migrationBuilder.InsertData(
                table: "TargetViewTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8702), false, null, null, "Progress Bar" },
                    { 2, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8704), false, null, null, "Bilgi" }
                });

            migrationBuilder.InsertData(
                table: "TriggerTimes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8723), false, null, null, "Hedefe Ulaşıldığı Anda" },
                    { 2, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8724), false, null, null, "Tamamlandıktan Sonra" }
                });

            migrationBuilder.InsertData(
                table: "VerificationTimes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8787), false, null, null, "İlk Kontrol Edildiğinde" },
                    { 2, "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8789), false, null, null, "Her Kontrol Edildiğinde" }
                });

            migrationBuilder.InsertData(
                table: "ViewOptions",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "SK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8168), false, null, null, "Sürekli Kampanyalar" },
                    { 2, "GK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8172), false, null, null, "Geçici Kampanyalar" },
                    { 3, "AK", "1", new DateTime(2022, 3, 3, 11, 11, 59, 690, DateTimeKind.Local).AddTicks(8175), false, null, null, "Anlık Kampanyalar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignAchievements_CampaignChannelId",
                table: "CampaignAchievements",
                column: "CampaignChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignAchievements_CurrencyId",
                table: "CampaignAchievements",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignDetails_CampaignId",
                table: "CampaignDetails",
                column: "CampaignId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignDocuments_CampaignId",
                table: "CampaignDocuments",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRuleBranches_CampaignRuleId",
                table: "CampaignRuleBranches",
                column: "CampaignRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRuleBusinesses_BusinessLineId",
                table: "CampaignRuleBusinesses",
                column: "BusinessLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRuleBusinesses_CampaignRuleId",
                table: "CampaignRuleBusinesses",
                column: "CampaignRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRuleCustomerTypes_CampaignRuleId",
                table: "CampaignRuleCustomerTypes",
                column: "CampaignRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRuleCustomerTypes_CustomerTypeId",
                table: "CampaignRuleCustomerTypes",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRuleIdentities_CampaignRuleId",
                table: "CampaignRuleIdentities",
                column: "CampaignRuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRules_CampaignId",
                table: "CampaignRules",
                column: "CampaignId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRules_CampaignStartTermId",
                table: "CampaignRules",
                column: "CampaignStartTermId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRules_JoinTypeId",
                table: "CampaignRules",
                column: "JoinTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_ActionOptionId",
                table: "Campaigns",
                column: "ActionOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_ProgramTypeId",
                table: "Campaigns",
                column: "ProgramTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_SectorId",
                table: "Campaigns",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_ViewOptionId",
                table: "Campaigns",
                column: "ViewOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTargets_CampaignId",
                table: "CampaignTargets",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTargets_TargetDefinitionId",
                table: "CampaignTargets",
                column: "TargetDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTargets_TargetOperationId",
                table: "CampaignTargets",
                column: "TargetOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTopLimits_AchievementFrequencyId",
                table: "CampaignTopLimits",
                column: "AchievementFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTopLimits_CampaignId",
                table: "CampaignTopLimits",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTopLimits_CurrencyId",
                table: "CampaignTopLimits",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetDetails_TargetId",
                table: "TargetDetails",
                column: "TargetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TargetDetails_TargetSourceId",
                table: "TargetDetails",
                column: "TargetSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetDetails_TargetViewTypeId",
                table: "TargetDetails",
                column: "TargetViewTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetDetails_TriggerTimeId",
                table: "TargetDetails",
                column: "TriggerTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetDetails_VerificationTimeId",
                table: "TargetDetails",
                column: "VerificationTimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "CampaignAchievements");

            migrationBuilder.DropTable(
                name: "CampaignDetails");

            migrationBuilder.DropTable(
                name: "CampaignDocuments");

            migrationBuilder.DropTable(
                name: "CampaignRuleBranches");

            migrationBuilder.DropTable(
                name: "CampaignRuleBusinesses");

            migrationBuilder.DropTable(
                name: "CampaignRuleCustomerTypes");

            migrationBuilder.DropTable(
                name: "CampaignRuleIdentities");

            migrationBuilder.DropTable(
                name: "CampaignTargets");

            migrationBuilder.DropTable(
                name: "CampaignTopLimits");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "TargetDetails");

            migrationBuilder.DropTable(
                name: "CampaignChannels");

            migrationBuilder.DropTable(
                name: "BusinessLines");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropTable(
                name: "CampaignRules");

            migrationBuilder.DropTable(
                name: "TargetDefinitions");

            migrationBuilder.DropTable(
                name: "TargetOperations");

            migrationBuilder.DropTable(
                name: "AchievementFrequencies");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "TargetSources");

            migrationBuilder.DropTable(
                name: "TargetViewTypes");

            migrationBuilder.DropTable(
                name: "TriggerTimes");

            migrationBuilder.DropTable(
                name: "VerificationTimes");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "CampaignStartTerms");

            migrationBuilder.DropTable(
                name: "JoinTypes");

            migrationBuilder.DropTable(
                name: "ActionOptions");

            migrationBuilder.DropTable(
                name: "ProgramTypes");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "ViewOptions");
        }
    }
}

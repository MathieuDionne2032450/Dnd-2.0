using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_DnD.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Campagne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Desc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campagne", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hitDie = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    primaryAbility = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enchantement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modif = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enchantement", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Key",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApiKey = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Monstre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArmorClass = table.Column<int>(type: "int", nullable: false),
                    HitPoint = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    FlySpeed = table.Column<int>(type: "int", nullable: false),
                    ClimbSpeed = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<int>(type: "int", nullable: false),
                    Dex = table.Column<int>(type: "int", nullable: false),
                    Con = table.Column<int>(type: "int", nullable: false),
                    Intel = table.Column<int>(type: "int", nullable: false),
                    Wis = table.Column<int>(type: "int", nullable: false),
                    Cha = table.Column<int>(type: "int", nullable: false),
                    DarkVision = table.Column<int>(type: "int", nullable: false),
                    Challenge = table.Column<float>(type: "float", nullable: false),
                    Lang = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DammageResistance = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DammageImmunities = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConditionImmunities = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monstre", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PNJ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bouche = table.Column<int>(type: "int", nullable: false),
                    Nez = table.Column<int>(type: "int", nullable: false),
                    Barbe = table.Column<int>(type: "int", nullable: false),
                    Cheveux = table.Column<int>(type: "int", nullable: false),
                    Sourcil = table.Column<int>(type: "int", nullable: false),
                    Tete = table.Column<int>(type: "int", nullable: false),
                    Yeux1 = table.Column<int>(type: "int", nullable: false),
                    Yeux2 = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PNJ", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BonusPV = table.Column<int>(type: "int", nullable: false),
                    BonusDex = table.Column<int>(type: "int", nullable: false),
                    BonusForce = table.Column<int>(type: "int", nullable: false),
                    BonusIntel = table.Column<int>(type: "int", nullable: false),
                    BonusWisdom = table.Column<int>(type: "int", nullable: false),
                    BonusConsti = table.Column<int>(type: "int", nullable: false),
                    BonusCharisma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descr = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dammage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DammageType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dc = table.Column<int>(type: "int", nullable: false),
                    DcType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CampagneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Campagne_CampagneId",
                        column: x => x.CampagneId,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CampagneClasses",
                columns: table => new
                {
                    CampagneId = table.Column<int>(type: "int", nullable: false),
                    Classesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampagneClasses", x => new { x.CampagneId, x.Classesid });
                    table.ForeignKey(
                        name: "FK_CampagneClasses_Campagne_CampagneId",
                        column: x => x.CampagneId,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampagneClasses_Classes_Classesid",
                        column: x => x.Classesid,
                        principalTable: "Classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Armure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ac = table.Column<int>(type: "int", nullable: false),
                    DexBonus = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MaxDexMod = table.Column<int>(type: "int", nullable: false),
                    StealthDisadvantage = table.Column<int>(type: "int", nullable: false),
                    EnchantementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armure_Enchantement_EnchantementId",
                        column: x => x.EnchantementId,
                        principalTable: "Enchantement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CampagneEnchantement",
                columns: table => new
                {
                    CampagneId = table.Column<int>(type: "int", nullable: false),
                    EnchantementsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampagneEnchantement", x => new { x.CampagneId, x.EnchantementsId });
                    table.ForeignKey(
                        name: "FK_CampagneEnchantement_Campagne_CampagneId",
                        column: x => x.CampagneId,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampagneEnchantement_Enchantement_EnchantementsId",
                        column: x => x.EnchantementsId,
                        principalTable: "Enchantement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CampagneMonstre",
                columns: table => new
                {
                    CampagneId = table.Column<int>(type: "int", nullable: false),
                    MonstresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampagneMonstre", x => new { x.CampagneId, x.MonstresId });
                    table.ForeignKey(
                        name: "FK_CampagneMonstre_Campagne_CampagneId",
                        column: x => x.CampagneId,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampagneMonstre_Monstre_MonstresId",
                        column: x => x.MonstresId,
                        principalTable: "Monstre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CampagnePNJ",
                columns: table => new
                {
                    CampagneId = table.Column<int>(type: "int", nullable: false),
                    PNJsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampagnePNJ", x => new { x.CampagneId, x.PNJsId });
                    table.ForeignKey(
                        name: "FK_CampagnePNJ_Campagne_CampagneId",
                        column: x => x.CampagneId,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampagnePNJ_PNJ_PNJsId",
                        column: x => x.PNJsId,
                        principalTable: "PNJ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Quete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PnjId = table.Column<int>(type: "int", nullable: false),
                    DescriptionQuete = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    reward = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quete_PNJ_PnjId",
                        column: x => x.PnjId,
                        principalTable: "PNJ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CampagneRace",
                columns: table => new
                {
                    CampagnesId = table.Column<int>(type: "int", nullable: false),
                    RacesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampagneRace", x => new { x.CampagnesId, x.RacesId });
                    table.ForeignKey(
                        name: "FK_CampagneRace_Campagne_CampagnesId",
                        column: x => x.CampagnesId,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampagneRace_Race_RacesId",
                        column: x => x.RacesId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActionMonstre",
                columns: table => new
                {
                    ActionsId = table.Column<int>(type: "int", nullable: false),
                    MonstresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionMonstre", x => new { x.ActionsId, x.MonstresId });
                    table.ForeignKey(
                        name: "FK_ActionMonstre_Actions_ActionsId",
                        column: x => x.ActionsId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionMonstre_Monstre_MonstresId",
                        column: x => x.MonstresId,
                        principalTable: "Monstre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArmureCampagne",
                columns: table => new
                {
                    ArmuresId = table.Column<int>(type: "int", nullable: false),
                    CampagneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmureCampagne", x => new { x.ArmuresId, x.CampagneId });
                    table.ForeignKey(
                        name: "FK_ArmureCampagne_Armure_ArmuresId",
                        column: x => x.ArmuresId,
                        principalTable: "Armure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmureCampagne_Campagne_CampagneId",
                        column: x => x.CampagneId,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Perso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrlJoueur = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inspiration = table.Column<int>(type: "int", nullable: false),
                    ArmureId = table.Column<int>(type: "int", nullable: false),
                    ClasseId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    Personalitetrait = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ideal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bonds = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Flaws = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Niv = table.Column<int>(type: "int", nullable: false),
                    CampagneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perso", x => x.id);
                    table.ForeignKey(
                        name: "FK_Perso_Armure_ArmureId",
                        column: x => x.ArmureId,
                        principalTable: "Armure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perso_Campagne_CampagneId",
                        column: x => x.CampagneId,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perso_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perso_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CampagneQuete",
                columns: table => new
                {
                    CampagneId = table.Column<int>(type: "int", nullable: false),
                    QuetesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampagneQuete", x => new { x.CampagneId, x.QuetesId });
                    table.ForeignKey(
                        name: "FK_CampagneQuete_Campagne_CampagneId",
                        column: x => x.CampagneId,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampagneQuete_Quete_QuetesId",
                        column: x => x.QuetesId,
                        principalTable: "Quete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Arme",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BonusJet = table.Column<int>(type: "int", nullable: false),
                    BonusForce = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnchantementId = table.Column<int>(type: "int", nullable: false),
                    Persoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arme", x => x.id);
                    table.ForeignKey(
                        name: "FK_Arme_Enchantement_EnchantementId",
                        column: x => x.EnchantementId,
                        principalTable: "Enchantement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arme_Perso_Persoid",
                        column: x => x.Persoid,
                        principalTable: "Perso",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "feats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descr = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Persoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feats", x => x.id);
                    table.ForeignKey(
                        name: "FK_feats_Perso_Persoid",
                        column: x => x.Persoid,
                        principalTable: "Perso",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descr = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Persoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.id);
                    table.ForeignKey(
                        name: "FK_Skill_Perso_Persoid",
                        column: x => x.Persoid,
                        principalTable: "Perso",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArmeCampagne",
                columns: table => new
                {
                    Armesid = table.Column<int>(type: "int", nullable: false),
                    CampagneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmeCampagne", x => new { x.Armesid, x.CampagneId });
                    table.ForeignKey(
                        name: "FK_ArmeCampagne_Arme_Armesid",
                        column: x => x.Armesid,
                        principalTable: "Arme",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmeCampagne_Campagne_CampagneId",
                        column: x => x.CampagneId,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ActionMonstre_MonstresId",
                table: "ActionMonstre",
                column: "MonstresId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CampagneId",
                table: "Actions",
                column: "CampagneId");

            migrationBuilder.CreateIndex(
                name: "IX_Arme_EnchantementId",
                table: "Arme",
                column: "EnchantementId");

            migrationBuilder.CreateIndex(
                name: "IX_Arme_Persoid",
                table: "Arme",
                column: "Persoid");

            migrationBuilder.CreateIndex(
                name: "IX_ArmeCampagne_CampagneId",
                table: "ArmeCampagne",
                column: "CampagneId");

            migrationBuilder.CreateIndex(
                name: "IX_Armure_EnchantementId",
                table: "Armure",
                column: "EnchantementId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmureCampagne_CampagneId",
                table: "ArmureCampagne",
                column: "CampagneId");

            migrationBuilder.CreateIndex(
                name: "IX_CampagneClasses_Classesid",
                table: "CampagneClasses",
                column: "Classesid");

            migrationBuilder.CreateIndex(
                name: "IX_CampagneEnchantement_EnchantementsId",
                table: "CampagneEnchantement",
                column: "EnchantementsId");

            migrationBuilder.CreateIndex(
                name: "IX_CampagneMonstre_MonstresId",
                table: "CampagneMonstre",
                column: "MonstresId");

            migrationBuilder.CreateIndex(
                name: "IX_CampagnePNJ_PNJsId",
                table: "CampagnePNJ",
                column: "PNJsId");

            migrationBuilder.CreateIndex(
                name: "IX_CampagneQuete_QuetesId",
                table: "CampagneQuete",
                column: "QuetesId");

            migrationBuilder.CreateIndex(
                name: "IX_CampagneRace_RacesId",
                table: "CampagneRace",
                column: "RacesId");

            migrationBuilder.CreateIndex(
                name: "IX_feats_Persoid",
                table: "feats",
                column: "Persoid");

            migrationBuilder.CreateIndex(
                name: "IX_Perso_ArmureId",
                table: "Perso",
                column: "ArmureId");

            migrationBuilder.CreateIndex(
                name: "IX_Perso_CampagneId",
                table: "Perso",
                column: "CampagneId");

            migrationBuilder.CreateIndex(
                name: "IX_Perso_ClasseId",
                table: "Perso",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Perso_RaceId",
                table: "Perso",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Quete_PnjId",
                table: "Quete",
                column: "PnjId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_Persoid",
                table: "Skill",
                column: "Persoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionMonstre");

            migrationBuilder.DropTable(
                name: "ArmeCampagne");

            migrationBuilder.DropTable(
                name: "ArmureCampagne");

            migrationBuilder.DropTable(
                name: "CampagneClasses");

            migrationBuilder.DropTable(
                name: "CampagneEnchantement");

            migrationBuilder.DropTable(
                name: "CampagneMonstre");

            migrationBuilder.DropTable(
                name: "CampagnePNJ");

            migrationBuilder.DropTable(
                name: "CampagneQuete");

            migrationBuilder.DropTable(
                name: "CampagneRace");

            migrationBuilder.DropTable(
                name: "feats");

            migrationBuilder.DropTable(
                name: "Key");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Arme");

            migrationBuilder.DropTable(
                name: "Monstre");

            migrationBuilder.DropTable(
                name: "Quete");

            migrationBuilder.DropTable(
                name: "Perso");

            migrationBuilder.DropTable(
                name: "PNJ");

            migrationBuilder.DropTable(
                name: "Armure");

            migrationBuilder.DropTable(
                name: "Campagne");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Enchantement");
        }
    }
}

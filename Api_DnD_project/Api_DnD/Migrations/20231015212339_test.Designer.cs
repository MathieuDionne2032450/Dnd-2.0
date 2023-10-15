﻿// <auto-generated />
using System;
using Api_DnD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api_DnD.Migrations
{
    [DbContext(typeof(DNDContext))]
<<<<<<<< HEAD:Api_DnD_project/Api_DnD/Migrations/20231015212339_test.Designer.cs
    [Migration("20231015212339_test")]
    partial class test
========
    [Migration("20231015210705_LocalDB")]
    partial class LocalDB
>>>>>>>> ac3a95fe55ede1b43054bfc65db5bed22be7f494:Api_DnD_project/Api_DnD/Migrations/20231015210705_LocalDB.Designer.cs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ActionMonstre", b =>
                {
                    b.Property<int>("ActionsId")
                        .HasColumnType("int");

                    b.Property<int>("MonstresId")
                        .HasColumnType("int");

                    b.HasKey("ActionsId", "MonstresId");

                    b.HasIndex("MonstresId");

                    b.ToTable("ActionMonstre");
                });

            modelBuilder.Entity("Api_DnD.Model.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CampagneId")
                        .HasColumnType("int");

                    b.Property<string>("Dammage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DammageType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Dc")
                        .HasColumnType("int");

                    b.Property<string>("DcType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CampagneId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Api_DnD.Model.Arme", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BonusForce")
                        .HasColumnType("int");

                    b.Property<int>("BonusJet")
                        .HasColumnType("int");

                    b.Property<int>("EnchantementId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Persoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("EnchantementId");

                    b.HasIndex("Persoid");

                    b.ToTable("Arme", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.Armure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ac")
                        .HasColumnType("int");

                    b.Property<bool>("DexBonus")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("EnchantementId")
                        .HasColumnType("int");

                    b.Property<int>("MaxDexMod")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StealthDisadvantage")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnchantementId");

                    b.ToTable("Armure", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.Campagne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Campagne", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.Classes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("hitDie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("primaryAbility")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Classes", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.Enchantement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Modif")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Enchantement", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.Key", b =>
                {
                    b.Property<string>("ApiKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ApiKey");

                    b.ToTable("Key", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.Monstre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArmorClass")
                        .HasColumnType("int");

                    b.Property<int>("Cha")
                        .HasColumnType("int");

                    b.Property<float>("Challenge")
                        .HasColumnType("float");

                    b.Property<int>("ClimbSpeed")
                        .HasColumnType("int");

                    b.Property<int>("Con")
                        .HasColumnType("int");

                    b.Property<string>("ConditionImmunities")
                        .HasColumnType("longtext");

                    b.Property<string>("DammageImmunities")
                        .HasColumnType("longtext");

                    b.Property<string>("DammageResistance")
                        .HasColumnType("longtext");

                    b.Property<int>("DarkVision")
                        .HasColumnType("int");

                    b.Property<int>("Dex")
                        .HasColumnType("int");

                    b.Property<int>("FlySpeed")
                        .HasColumnType("int");

                    b.Property<int>("HitPoint")
                        .HasColumnType("int");

                    b.Property<int>("Intel")
                        .HasColumnType("int");

                    b.Property<string>("Lang")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Str")
                        .HasColumnType("int");

                    b.Property<int>("Wis")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Monstre", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.PNJ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Barbe")
                        .HasColumnType("int");

                    b.Property<int>("Bouche")
                        .HasColumnType("int");

                    b.Property<int>("Cheveux")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Nez")
                        .HasColumnType("int");

                    b.Property<int>("Sourcil")
                        .HasColumnType("int");

                    b.Property<int>("Tete")
                        .HasColumnType("int");

                    b.Property<int>("Yeux1")
                        .HasColumnType("int");

                    b.Property<int>("Yeux2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PNJ", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.Perso", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArmureId")
                        .HasColumnType("int");

                    b.Property<string>("Bonds")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CampagneId")
                        .HasColumnType("int");

                    b.Property<int>("ClasseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Flaws")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ideal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Inspiration")
                        .HasColumnType("int");

                    b.Property<string>("IrlJoueur")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Niv")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Personalitetrait")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ArmureId");

                    b.HasIndex("CampagneId");

                    b.HasIndex("ClasseId");

                    b.HasIndex("RaceId");

                    b.ToTable("Perso", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.Quete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescriptionQuete")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PnjId")
                        .HasColumnType("int");

                    b.Property<string>("reward")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PnjId");

                    b.ToTable("Quete", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BonusCharisma")
                        .HasColumnType("int");

                    b.Property<int>("BonusConsti")
                        .HasColumnType("int");

                    b.Property<int>("BonusDex")
                        .HasColumnType("int");

                    b.Property<int>("BonusForce")
                        .HasColumnType("int");

                    b.Property<int>("BonusIntel")
                        .HasColumnType("int");

                    b.Property<int>("BonusPV")
                        .HasColumnType("int");

                    b.Property<int>("BonusWisdom")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Race", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.Skill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Skill");
                });

<<<<<<<< HEAD:Api_DnD_project/Api_DnD/Migrations/20231015212339_test.Designer.cs
            modelBuilder.Entity("Api_DnD.Model.feats", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("feats");
                });

            modelBuilder.Entity("Api_DnD.Model.spell", b =>
========
            modelBuilder.Entity("Api_DnD.Model.Spell", b =>
>>>>>>>> ac3a95fe55ede1b43054bfc65db5bed22be7f494:Api_DnD_project/Api_DnD/Migrations/20231015210705_LocalDB.Designer.cs
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Dammage")
                        .HasColumnType("int");

                    b.Property<string>("DammageType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Zone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("spell", (string)null);
                });

            modelBuilder.Entity("Api_DnD.Model.feats", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Persoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Persoid");

                    b.ToTable("Feats");
                });

            modelBuilder.Entity("ArmeCampagne", b =>
                {
                    b.Property<int>("Armesid")
                        .HasColumnType("int");

                    b.Property<int>("CampagneId")
                        .HasColumnType("int");

                    b.HasKey("Armesid", "CampagneId");

                    b.HasIndex("CampagneId");

                    b.ToTable("ArmeCampagne");
                });

            modelBuilder.Entity("ArmureCampagne", b =>
                {
                    b.Property<int>("ArmuresId")
                        .HasColumnType("int");

                    b.Property<int>("CampagneId")
                        .HasColumnType("int");

                    b.HasKey("ArmuresId", "CampagneId");

                    b.HasIndex("CampagneId");

                    b.ToTable("ArmureCampagne");
                });

            modelBuilder.Entity("CampagneClasses", b =>
                {
                    b.Property<int>("CampagneId")
                        .HasColumnType("int");

                    b.Property<int>("Classesid")
                        .HasColumnType("int");

                    b.HasKey("CampagneId", "Classesid");

                    b.HasIndex("Classesid");

                    b.ToTable("CampagneClasses");
                });

            modelBuilder.Entity("CampagneEnchantement", b =>
                {
                    b.Property<int>("CampagneId")
                        .HasColumnType("int");

                    b.Property<int>("EnchantementsId")
                        .HasColumnType("int");

                    b.HasKey("CampagneId", "EnchantementsId");

                    b.HasIndex("EnchantementsId");

                    b.ToTable("CampagneEnchantement");
                });

            modelBuilder.Entity("CampagneMonstre", b =>
                {
                    b.Property<int>("CampagneId")
                        .HasColumnType("int");

                    b.Property<int>("MonstresId")
                        .HasColumnType("int");

                    b.HasKey("CampagneId", "MonstresId");

                    b.HasIndex("MonstresId");

                    b.ToTable("CampagneMonstre");
                });

            modelBuilder.Entity("CampagnePNJ", b =>
                {
                    b.Property<int>("CampagneId")
                        .HasColumnType("int");

                    b.Property<int>("PNJsId")
                        .HasColumnType("int");

                    b.HasKey("CampagneId", "PNJsId");

                    b.HasIndex("PNJsId");

                    b.ToTable("CampagnePNJ");
                });

            modelBuilder.Entity("CampagneQuete", b =>
                {
                    b.Property<int>("CampagneId")
                        .HasColumnType("int");

                    b.Property<int>("QuetesId")
                        .HasColumnType("int");

                    b.HasKey("CampagneId", "QuetesId");

                    b.HasIndex("QuetesId");

                    b.ToTable("CampagneQuete");
                });

            modelBuilder.Entity("CampagneRace", b =>
                {
                    b.Property<int>("CampagnesId")
                        .HasColumnType("int");

                    b.Property<int>("RacesId")
                        .HasColumnType("int");

                    b.HasKey("CampagnesId", "RacesId");

                    b.HasIndex("RacesId");

                    b.ToTable("CampagneRace");
                });

            modelBuilder.Entity("PersoSkill", b =>
                {
                    b.Property<int>("Persosid")
                        .HasColumnType("int");

                    b.Property<int>("Skillsid")
                        .HasColumnType("int");

                    b.HasKey("Persosid", "Skillsid");

                    b.HasIndex("Skillsid");

                    b.ToTable("PersoSkill");
                });

            modelBuilder.Entity("Persofeats", b =>
                {
                    b.Property<int>("Persosid")
                        .HasColumnType("int");

                    b.Property<int>("featsid")
                        .HasColumnType("int");

                    b.HasKey("Persosid", "featsid");

                    b.HasIndex("featsid");

                    b.ToTable("Persofeats");
                });

            modelBuilder.Entity("ActionMonstre", b =>
                {
                    b.HasOne("Api_DnD.Model.Action", null)
                        .WithMany()
                        .HasForeignKey("ActionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Monstre", null)
                        .WithMany()
                        .HasForeignKey("MonstresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api_DnD.Model.Action", b =>
                {
                    b.HasOne("Api_DnD.Model.Campagne", "Campagne")
                        .WithMany()
                        .HasForeignKey("CampagneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campagne");
                });

            modelBuilder.Entity("Api_DnD.Model.Arme", b =>
                {
                    b.HasOne("Api_DnD.Model.Enchantement", "Enchantement")
                        .WithMany()
                        .HasForeignKey("EnchantementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Perso", null)
                        .WithMany("LesArmes")
                        .HasForeignKey("Persoid");

                    b.Navigation("Enchantement");
                });

            modelBuilder.Entity("Api_DnD.Model.Armure", b =>
                {
                    b.HasOne("Api_DnD.Model.Enchantement", "Enchantement")
                        .WithMany()
                        .HasForeignKey("EnchantementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enchantement");
                });

            modelBuilder.Entity("Api_DnD.Model.Perso", b =>
                {
                    b.HasOne("Api_DnD.Model.Armure", "Armure")
                        .WithMany()
                        .HasForeignKey("ArmureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Campagne", "Campagne")
                        .WithMany()
                        .HasForeignKey("CampagneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Classes", "Classes")
                        .WithMany()
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Armure");

                    b.Navigation("Campagne");

                    b.Navigation("Classes");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("Api_DnD.Model.Quete", b =>
                {
                    b.HasOne("Api_DnD.Model.PNJ", "Pnj")
                        .WithMany("Quetes")
                        .HasForeignKey("PnjId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pnj");
                });

            modelBuilder.Entity("ArmeCampagne", b =>
                {
                    b.HasOne("Api_DnD.Model.Arme", null)
                        .WithMany()
                        .HasForeignKey("Armesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Campagne", null)
                        .WithMany()
                        .HasForeignKey("CampagneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArmureCampagne", b =>
                {
                    b.HasOne("Api_DnD.Model.Armure", null)
                        .WithMany()
                        .HasForeignKey("ArmuresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Campagne", null)
                        .WithMany()
                        .HasForeignKey("CampagneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampagneClasses", b =>
                {
                    b.HasOne("Api_DnD.Model.Campagne", null)
                        .WithMany()
                        .HasForeignKey("CampagneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Classes", null)
                        .WithMany()
                        .HasForeignKey("Classesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampagneEnchantement", b =>
                {
                    b.HasOne("Api_DnD.Model.Campagne", null)
                        .WithMany()
                        .HasForeignKey("CampagneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Enchantement", null)
                        .WithMany()
                        .HasForeignKey("EnchantementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampagneMonstre", b =>
                {
                    b.HasOne("Api_DnD.Model.Campagne", null)
                        .WithMany()
                        .HasForeignKey("CampagneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Monstre", null)
                        .WithMany()
                        .HasForeignKey("MonstresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampagnePNJ", b =>
                {
                    b.HasOne("Api_DnD.Model.Campagne", null)
                        .WithMany()
                        .HasForeignKey("CampagneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.PNJ", null)
                        .WithMany()
                        .HasForeignKey("PNJsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampagneQuete", b =>
                {
                    b.HasOne("Api_DnD.Model.Campagne", null)
                        .WithMany()
                        .HasForeignKey("CampagneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Quete", null)
                        .WithMany()
                        .HasForeignKey("QuetesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampagneRace", b =>
                {
                    b.HasOne("Api_DnD.Model.Campagne", null)
                        .WithMany()
                        .HasForeignKey("CampagnesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Race", null)
                        .WithMany()
                        .HasForeignKey("RacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersoSkill", b =>
                {
                    b.HasOne("Api_DnD.Model.Perso", null)
                        .WithMany()
                        .HasForeignKey("Persosid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.Skill", null)
                        .WithMany()
                        .HasForeignKey("Skillsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Persofeats", b =>
                {
                    b.HasOne("Api_DnD.Model.Perso", null)
                        .WithMany()
                        .HasForeignKey("Persosid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_DnD.Model.feats", null)
                        .WithMany()
                        .HasForeignKey("featsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api_DnD.Model.PNJ", b =>
                {
                    b.Navigation("Quetes");
                });

            modelBuilder.Entity("Api_DnD.Model.Perso", b =>
                {
                    b.Navigation("LesArmes");
                });
#pragma warning restore 612, 618
        }
    }
}

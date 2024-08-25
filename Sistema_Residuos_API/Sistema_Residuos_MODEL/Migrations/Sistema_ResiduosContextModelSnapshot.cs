﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_Residuos_MODEL.Models;

#nullable disable

namespace Sistema_Residuos_MODEL.Migrations
{
    [DbContext(typeof(Sistema_ResiduosContext))]
    partial class Sistema_ResiduosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.CalendarioColetum", b =>
                {
                    b.Property<int>("CalendarioColetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalendarioColetaId"));

                    b.Property<string>("DiaSemana")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<TimeOnly>("Horario")
                        .HasColumnType("time");

                    b.Property<int?>("TipoResiduoId")
                        .HasColumnType("int");

                    b.HasKey("CalendarioColetaId")
                        .HasName("PK__Calendar__D356C6628AB9F36E");

                    b.HasIndex("TipoResiduoId");

                    b.HasIndex(new[] { "DiaSemana", "Horario" }, "idx_calendariocoleta_dia_horario");

                    b.ToTable("CalendarioColeta");
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.Notificaco", b =>
                {
                    b.Property<int>("NotificacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificacaoId"));

                    b.Property<DateTime>("DataEnvio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ResidenciaEstabelecimentoId")
                        .HasColumnType("int");

                    b.HasKey("NotificacaoId")
                        .HasName("PK__Notifica__FB9B787CB2C2698D");

                    b.HasIndex("ResidenciaEstabelecimentoId");

                    b.HasIndex(new[] { "DataEnvio" }, "idx_notificacoes_dataenvio");

                    b.ToTable("Notificacoes");
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.PontosColetum", b =>
                {
                    b.Property<int>("PontoColetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PontoColetaId"));

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(9, 6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(9, 6)");

                    b.Property<int>("TipoResiduoId")
                        .HasColumnType("int");

                    b.HasKey("PontoColetaId")
                        .HasName("PK__PontosCo__CAA22F7505950A60");

                    b.HasIndex("TipoResiduoId");

                    b.HasIndex(new[] { "Latitude", "Longitude" }, "idx_pontoscoleta_localizacao");

                    b.ToTable("PontosColeta");
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.ResidenciasEstabelecimento", b =>
                {
                    b.Property<int>("ResidenciaEstabelecimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResidenciaEstabelecimentoId"));

                    b.Property<string>("NomeResidencia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nomeResidencia");

                    b.Property<int>("TipoEstabelecimentoId")
                        .HasColumnType("int");

                    b.HasKey("ResidenciaEstabelecimentoId")
                        .HasName("PK__Residenc__7D5516AEE0B5C2F4");

                    b.HasIndex("TipoEstabelecimentoId");

                    b.HasIndex(new[] { "NomeResidencia" }, "idx_residencias_nome");

                    b.ToTable("ResidenciasEstabelecimentos");
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.TiposEstabelecimento", b =>
                {
                    b.Property<int>("TipoEstabelecimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoEstabelecimentoId"));

                    b.HasKey("TipoEstabelecimentoId")
                        .HasName("PK__TiposEst__FA95A1FF5EF7371A");

                    b.HasIndex(new[] { "TipoEstabelecimentoId" }, "UQ__TiposEst__FA95A1FEB6543652")
                        .IsUnique();

                    b.ToTable("TiposEstabelecimento", (string)null);
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.TiposResiduo", b =>
                {
                    b.Property<int>("TipoResiduoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoResiduoId"));

                    b.HasKey("TipoResiduoId")
                        .HasName("PK__TiposRes__C9AE64543FF14DB3");

                    b.HasIndex(new[] { "TipoResiduoId" }, "UQ__TiposRes__C9AE645581A4E1EB")
                        .IsUnique();

                    b.ToTable("TiposResiduo", (string)null);
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.CalendarioColetum", b =>
                {
                    b.HasOne("Sistema_Residuos_MODEL.Models.TiposResiduo", "TipoResiduo")
                        .WithMany("CalendarioColeta")
                        .HasForeignKey("TipoResiduoId")
                        .HasConstraintName("FK__Calendari__TipoR__3F466844");

                    b.Navigation("TipoResiduo");
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.Notificaco", b =>
                {
                    b.HasOne("Sistema_Residuos_MODEL.Models.ResidenciasEstabelecimento", "ResidenciaEstabelecimento")
                        .WithMany("Notificacos")
                        .HasForeignKey("ResidenciaEstabelecimentoId")
                        .IsRequired()
                        .HasConstraintName("FK__Notificac__Resid__4316F928");

                    b.Navigation("ResidenciaEstabelecimento");
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.PontosColetum", b =>
                {
                    b.HasOne("Sistema_Residuos_MODEL.Models.TiposResiduo", "TipoResiduo")
                        .WithMany("PontosColeta")
                        .HasForeignKey("TipoResiduoId")
                        .IsRequired()
                        .HasConstraintName("FK__PontosCol__TipoR__45F365D3");

                    b.Navigation("TipoResiduo");
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.ResidenciasEstabelecimento", b =>
                {
                    b.HasOne("Sistema_Residuos_MODEL.Models.TiposEstabelecimento", "TipoEstabelecimento")
                        .WithMany("ResidenciasEstabelecimentos")
                        .HasForeignKey("TipoEstabelecimentoId")
                        .IsRequired()
                        .HasConstraintName("FK__Residenci__TipoE__398D8EEE");

                    b.Navigation("TipoEstabelecimento");
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.ResidenciasEstabelecimento", b =>
                {
                    b.Navigation("Notificacos");
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.TiposEstabelecimento", b =>
                {
                    b.Navigation("ResidenciasEstabelecimentos");
                });

            modelBuilder.Entity("Sistema_Residuos_MODEL.Models.TiposResiduo", b =>
                {
                    b.Navigation("CalendarioColeta");

                    b.Navigation("PontosColeta");
                });
#pragma warning restore 612, 618
        }
    }
}
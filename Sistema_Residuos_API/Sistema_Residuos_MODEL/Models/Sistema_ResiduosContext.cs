﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sistema_Residuos_MODEL.Models;

public partial class Sistema_ResiduosContext : DbContext
{
    public Sistema_ResiduosContext()
    {
    }

    public Sistema_ResiduosContext(DbContextOptions<Sistema_ResiduosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalendarioColetum> CalendarioColeta { get; set; }

    public virtual DbSet<Notificaco> Notificacoes { get; set; }

    public virtual DbSet<PontosColetum> PontosColeta { get; set; }

    public virtual DbSet<ResidenciasEstabelecimento> ResidenciasEstabelecimentos { get; set; }

    public virtual DbSet<TiposEstabelecimento> TiposEstabelecimentos { get; set; }

    public virtual DbSet<TiposResiduo> TiposResiduos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=jacknotebook\\sqlexpress;Initial Catalog=Sistema_Residuos;Integrated Security=True;trustservercertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalendarioColetum>(entity =>
        {
            entity.HasKey(e => e.CalendarioColetaId).HasName("PK__Calendar__D356C6628AB9F36E");           
            entity.HasIndex(e => new { e.DiaSemana, e.Horario }, "idx_calendariocoleta_dia_horario");           

            entity.Property(e => e.DiaSemana)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoResiduo).WithMany(p => p.CalendarioColeta)
                .HasForeignKey(d => d.TipoResiduoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calendari__TipoR__3F466844");
        });

        modelBuilder.Entity<Notificaco>(entity =>
        {
            entity.HasKey(e => e.NotificacaoId).HasName("PK__Notifica__FB9B787CB2C2698D");

            entity.HasIndex(e => e.DataEnvio, "idx_notificacoes_dataenvio");

            entity.Property(e => e.DataEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Mensagem)
                .IsRequired()
                .HasColumnType("text");

            entity.HasOne(d => d.ResidenciaEstabelecimento).WithMany(p => p.Notificacos)
                .HasForeignKey(d => d.ResidenciaEstabelecimentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__Resid__4316F928");
        });

        modelBuilder.Entity<PontosColetum>(entity =>
        {
            entity.HasKey(e => e.PontoColetaId).HasName("PK__PontosCo__CAA22F7505950A60");

            entity.HasIndex(e => new { e.Latitude, e.Longitude }, "idx_pontoscoleta_localizacao");

            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

            entity.HasOne(d => d.TipoResiduo).WithMany(p => p.PontosColeta)
                .HasForeignKey(d => d.TipoResiduoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PontosCol__TipoR__45F365D3");
        });

        modelBuilder.Entity<ResidenciasEstabelecimento>(entity =>
        {
            entity.HasKey(e => e.ResidenciaEstabelecimentoId).HasName("PK__Residenc__7D5516AEE0B5C2F4");

            entity.HasIndex(e => e.NomeResidencia, "idx_residencias_nome");

            entity.Property(e => e.NomeResidencia)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nomeResidencia");

            entity.HasOne(d => d.TipoEstabelecimento).WithMany(p => p.ResidenciasEstabelecimentos)
                .HasForeignKey(d => d.TipoEstabelecimentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Residenci__TipoE__398D8EEE");
        });

        modelBuilder.Entity<TiposEstabelecimento>(entity =>
        {
            entity.HasKey(e => e.TipoEstabelecimentoId).HasName("PK__TiposEst__FA95A1FF5EF7371A");

            entity.ToTable("TiposEstabelecimento");

            entity.HasIndex(e => e.TipoEstabelecimentoId, "UQ__TiposEst__FA95A1FEB6543652").IsUnique();
        });

        modelBuilder.Entity<TiposResiduo>(entity =>
        {
            entity.HasKey(e => e.TipoResiduoId).HasName("PK__TiposRes__C9AE64543FF14DB3");

            entity.ToTable("TiposResiduo");

            entity.HasIndex(e => e.TipoResiduoId, "UQ__TiposRes__C9AE645581A4E1EB").IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
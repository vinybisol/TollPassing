// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TollPassing.Context;

#nullable disable

namespace TollPassing.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20220129110945_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TollPassing.Models.TollPassingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("pas_datetime");

                    b.Property<DateTime>("DateTimeModification")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("pas_modifiedin")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("text")
                        .HasColumnName("pas_plate");

                    b.Property<string>("Vehicle")
                        .HasColumnType("text")
                        .HasColumnName("pas_vehicle");

                    b.HasKey("Id")
                        .HasName("pk_passing");

                    b.ToTable("passing", "public");
                });
#pragma warning restore 612, 618
        }
    }
}

// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreProceDureCrud.Data;

namespace StoreProceDureCrud.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreProceDureCrud.Data.Entity.City", b =>
                {
                    b.Property<int?>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("StoreProceDureCrud.Data.Entity.Country", b =>
                {
                    b.Property<int?>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("StoreProceDureCrud.Data.Entity.FavouriteHobby", b =>
                {
                    b.Property<int?>("FavouriteHobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HobbyId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("FavouriteHobbyId");

                    b.HasIndex("HobbyId");

                    b.HasIndex("ProfileId");

                    b.ToTable("FavouriteHobbies");
                });

            modelBuilder.Entity("StoreProceDureCrud.Data.Entity.Gender", b =>
                {
                    b.Property<int?>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("StoreProceDureCrud.Data.Entity.Hobby", b =>
                {
                    b.Property<int?>("HobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HobbyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HobbyId");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("StoreProceDureCrud.Data.Entity.Profile", b =>
                {
                    b.Property<int?>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("websiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileId");

                    b.HasIndex("CityId");

                    b.HasIndex("GenderId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("StoreProceDureCrud.Data.Entity.City", b =>
                {
                    b.HasOne("StoreProceDureCrud.Data.Entity.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("StoreProceDureCrud.Data.Entity.FavouriteHobby", b =>
                {
                    b.HasOne("StoreProceDureCrud.Data.Entity.Hobby", "Hobby")
                        .WithMany()
                        .HasForeignKey("HobbyId");

                    b.HasOne("StoreProceDureCrud.Data.Entity.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId");

                    b.Navigation("Hobby");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("StoreProceDureCrud.Data.Entity.Profile", b =>
                {
                    b.HasOne("StoreProceDureCrud.Data.Entity.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreProceDureCrud.Data.Entity.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.Navigation("City");

                    b.Navigation("Gender");
                });
#pragma warning restore 612, 618
        }
    }
}

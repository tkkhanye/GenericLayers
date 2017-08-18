using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreContext;
using CoreFacade.Enums;

namespace CoreContext.Migrations
{
    [DbContext(typeof(RepoContext))]
    [Migration("20170614063241_InitialGoodies")]
    partial class InitialGoodies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreFacade.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<Guid>("CreatedUserId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Line1");

                    b.Property<string>("Line2");

                    b.Property<string>("Line3");

                    b.Property<DateTime>("ModifiedTime");

                    b.Property<Guid>("ModifiedUserId");

                    b.Property<int>("PostalCode");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CoreFacade.Models.Dealer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<Guid>("CreatedUserId");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("ModifiedTime");

                    b.Property<Guid>("ModifiedUserId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Dealer");
                });

            modelBuilder.Entity("CoreFacade.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<Guid>("CreatedUserId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email");

                    b.Property<byte>("EstablishmentType");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("LastSuccessfulLogin");

                    b.Property<int>("LoginAttempts");

                    b.Property<DateTime>("ModifiedTime");

                    b.Property<Guid>("ModifiedUserId");

                    b.Property<string>("Password");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CoreFacade.Models.UserToken", b =>
                {
                    b.Property<string>("Token")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("ErrorMessage");

                    b.Property<DateTime>("Expiry");

                    b.Property<bool>("RequestSuccessful");

                    b.Property<Guid>("UserId");

                    b.HasKey("Token");

                    b.ToTable("UserToken");
                });
        }
    }
}

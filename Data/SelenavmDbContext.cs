using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SELENAVM04.Entities;
using System;
using System.Collections.Generic;

namespace SELENAVM04.Data
{
    public class SelenavmDbContext : DbContext
    {
        public DbSet<UrunlerXMLS> UrunlerXMLS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AzureSQLSelenavmConnection"));

            // Bu kodda, SelenavmDbContext sınıfını DbContext sınıfından türetiyoruz ve UrunlerXMLS adında bir DbSet özelliği ekliyoruz.
            // Bu DbSet özelliği, UrunlerXMLS tablosu üzerinde CRUD işlemleri yapmanızı sağlar.
            // UrunlerXMLS sınıfınızın tanımlanmış olduğundan ve projenizde mevcut olduğundan emin olun.
            // Bu sınıf, UrunlerXMLS tablosunun şemasını temsil eder.
        }

        // Bu metodu ekleyin
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrunlerXMLS>(entity =>
            {
                entity.Property(e => e.UrunKodu).HasMaxLength(50);
                entity.Property(e => e.UrunBarkodu).HasMaxLength(50);
                entity.Property(e => e.UrunAdi).HasMaxLength(255);
                entity.Property(e => e.UrunMarka).HasMaxLength(50);
                entity.Property(e => e.UrunAdeti).HasColumnType("int");
                entity.Property(e => e.UrunFiyati).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.VaryantKodu).HasMaxLength(50);
                entity.Property(e => e.UrunRengi).HasMaxLength(25);
                entity.Property(e => e.UrunModeli).HasMaxLength(25);
            });
        }
    }
}

// Açıklamalar.
//Harika! SelenavmDbContext sınıfınızı doğru bir şekilde tanımlamış görünüyorsunuz. Bu sınıf, Entity Framework Core'un veritabanı ile etkileşim kurabilmesi için gereklidir.
//UrunlerXMLS adında bir DbSet özelliği eklediniz, bu da UrunlerXMLS tablosu üzerinde CRUD (Create, Read, Update, Delete) işlemleri yapmanızı sağlar.
//OnConfiguring metodu içinde, veritabanı bağlantınızı yapılandırdınız. Bu metot, DbContext sınıfının bir örneği oluşturulurken çağrılır ve veritabanı bağlantınızı ayarlamanızı sağlar.
//OnModelCreating metodu içinde, UrunlerXMLS tablosunun her bir sütununun özelliklerini belirlediniz. Bu metot, Entity Framework Core'un veritabanı şemasını oluştururken kullanılır.
//Bu kod parçacığı, UrunlerXMLS tablosuna veri eklemenizi ve bu verileri sorgulamanızı sağlar. Bu kod parçacığı, SelenavmDbContext sınıfınızın tanımlandığı dosyada olmalıdır.














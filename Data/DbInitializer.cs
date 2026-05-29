using Microsoft.EntityFrameworkCore;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Models;

namespace T2502E_Assignment_Nguyen_anh_tu_NetCore.Data;

public class DbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Đảm bảo Database đã được tạo thông qua Migrations
            context.Database.Migrate();

            // 1. Thực hiện Reset dữ liệu
            /*ClearData(context);*/

            // 2. Thực hiện Seeding dữ liệu mới
            SeedSinger(context);
            SeedComposer(context);
            SeedSong(context);
        }
    }

    public static void SeedSinger(AppDbContext context)
    {
        if (context.Singers.Any())
        {
            return;
        }

        context.Singers.AddRange(new List<Singer>
        {
            new Singer {Name = "Ca sĩ 1", Biography = "Tiểu Sử 1", ImageUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779893083/mh6qo4ffi0tf8dcnkpvi.jpg"},
            new Singer {Name = "Ca sĩ 2", Biography = "Tiểu Sử 2", ImageUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779893083/mh6qo4ffi0tf8dcnkpvi.jpg"},
            new Singer {Name = "Ca sĩ 3", Biography = "Tiểu Sử 3", ImageUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779893083/mh6qo4ffi0tf8dcnkpvi.jpg"},
            new Singer {Name = "Ca sĩ 4", Biography = "Tiểu Sử 4", ImageUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779893083/mh6qo4ffi0tf8dcnkpvi.jpg"},
            new Singer {Name = "Ca sĩ 5", Biography = "Tiểu Sử 5", ImageUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779893083/mh6qo4ffi0tf8dcnkpvi.jpg"},
        });
        context.SaveChanges();

    }

    public static void SeedComposer(AppDbContext context)
    {
        if (context.Composers.Any())
        {
            return;
        }

        context.Composers.AddRange(new List<Composer>
        {
            new Composer {Name = "Nhạc sĩ 1", Biography = "Tiểu Sử 1", ImageUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg"},
            new Composer {Name = "Nhạc sĩ 2", Biography = "Tiểu Sử 2", ImageUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg"},
            new Composer {Name = "Nhạc sĩ 3", Biography = "Tiểu Sử 3", ImageUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg"},
            new Composer {Name = "Nhạc sĩ 4", Biography = "Tiểu Sử 4", ImageUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg"},
            new Composer {Name = "Nhạc sĩ 5", Biography = "Tiểu Sử 5", ImageUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg"},
        });
        context.SaveChanges();
    }
    
    public static void SeedSong(AppDbContext context)
    {
        if (context.Songs.Any())
        {
            return;
        }

        context.Songs.AddRange(new List<Song>
        {
            new Song {SingerId = 1, ComposerId = 2, Title = "Bài hái 1", Lyrics = "Lời 1", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 2, ComposerId = 3, Title = "Bài hái 2", Lyrics = "Lời 2", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 3, ComposerId = 2, Title = "Bài hái 3", Lyrics = "Lời 3", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 4, Title = "Bài hái 4", Lyrics = "Lời 4", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 5, ComposerId = 4, Title = "Bài hái 5", Lyrics = "Lời 5", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 2, Title = "Bài hái 6", Lyrics = "Lời 6", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 2, ComposerId = 4, Title = "Bài hái 7", Lyrics = "Lời 7", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 3, ComposerId = 2, Title = "Bài hái 8", Lyrics = "Lời 8", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 2, Title = "Bài hái 9", Lyrics = "Lời 9", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 5, ComposerId = 4, Title = "Bài hái 10", Lyrics = "Lời 10", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 2, ComposerId = 2, Title = "Bài hái 11", Lyrics = "Lời 11", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 3, ComposerId = 2, Title = "Bài hái 12", Lyrics = "Lời 12", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 2, Title = "Bài hái 13", Lyrics = "Lời 13", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 2, ComposerId = 2, Title = "Bài hái 14", Lyrics = "Lời 14", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 3, ComposerId = 2, Title = "Bài hái 15", Lyrics = "Lời 15", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 5, Title = "Bài hái 16", Lyrics = "Lời 16", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 5, ComposerId = 4, Title = "Bài hái 17", Lyrics = "Lời 17", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 3, ComposerId = 2, Title = "Bài hái 18", Lyrics = "Lời 18", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 5, ComposerId = 2, Title = "Bài hái 19", Lyrics = "Lời 19", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 2, Title = "Bài hái 20", Lyrics = "Lời 20", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 3, Title = "Bài hái 21", Lyrics = "Lời 21", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 3, ComposerId = 3, Title = "Bài hái 22", Lyrics = "Lời 22", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 5, ComposerId = 3, Title = "Bài hái 23", Lyrics = "Lời 23", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 4, Title = "Bài hái 24", Lyrics = "Lời 24", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 1, Title = "Bài hái 25", Lyrics = "Lời 25", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 3, ComposerId = 5, Title = "Bài hái 26", Lyrics = "Lời 26", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 4, Title = "Bài hái 27", Lyrics = "Lời 27", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 2, Title = "Bài hái 28", Lyrics = "Lời 28", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 2, Title = "Bài hái 29", Lyrics = "Lời 29", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 3, ComposerId = 2, Title = "Bài hái 30", Lyrics = "Lời 30", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 2, Title = "Bài hái 31", Lyrics = "Lời 31", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 2, ComposerId = 1, Title = "Bài hái 32", Lyrics = "Lời 32", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 4, Title = "Bài hái 33", Lyrics = "Lời 33", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 3, Title = "Bài hái 34", Lyrics = "Lời 34", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 4, Title = "Bài hái 35", Lyrics = "Lời 35", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 2, ComposerId = 5, Title = "Bài hái 36", Lyrics = "Lời 36", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 5, Title = "Bài hái 37", Lyrics = "Lời 37", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 5, ComposerId = 3, Title = "Bài hái 38", Lyrics = "Lời 38", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 2, Title = "Bài hái 39", Lyrics = "Lời 39", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 4, Title = "Bài hái 40", Lyrics = "Lời 40", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 2, Title = "Bài hái 41", Lyrics = "Lời 41", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 2, Title = "Bài hái 42", Lyrics = "Lời 42", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 4, ComposerId = 4, Title = "Bài hái 43", Lyrics = "Lời 43", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 3, Title = "Bài hái 44", Lyrics = "Lời 44", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 2, Title = "Bài hái 45", Lyrics = "Lời 45", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 2, Title = "Bài hái 46", Lyrics = "Lời 46", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 1, Title = "Bài hái 47", Lyrics = "Lời 47", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 3, ComposerId = 4, Title = "Bài hái 48", Lyrics = "Lời 48", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 3, Title = "Bài hái 49", Lyrics = "Lời 49", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},
            new Song {SingerId = 1, ComposerId = 2, Title = "Bài hái 50", Lyrics = "Lời 50", ThumbnailUrl = "https://res.cloudinary.com/nguyenanhtu/image/upload/v1779880293/wo4jkq02o9cwb4ezvtvw.jpg", Mp3Link = "https://res.cloudinary.com/nguyenanhtu/Video/Upload/V1780079569/Nrutdfwa279qap8pi5rs.Mp3", ReleaseDate = DateTime.Today, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today, Status = 1},

        });
        context.SaveChanges();
    }
}
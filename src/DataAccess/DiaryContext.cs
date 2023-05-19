using Microsoft.EntityFrameworkCore;
using System.IO;
public class DiaryContext : DbContext
{
    public DbSet<Entry> Entries { get; set; }
    public string DbPath { get; }

    // private static bool _created = false;
    public DiaryContext()
    {
        var dbdir = "./db";
        if(!Path.Exists(dbdir))
            Directory.CreateDirectory(dbdir);
        DbPath = Path.Join(dbdir, "diary.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Entry {
    public int Id {get;set; }
    public string Text {get;set; }="";
    public DateTimeOffset Created {get;set;}
    public DateTimeOffset Modified {get;set;}
}
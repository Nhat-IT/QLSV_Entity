using System;
using System.Data.Entity;
using System.Linq;

namespace CodeFirst_2008._4DTO
{
    public class QLSV2008 : DbContext
    {
        public QLSV2008()
            : base("name=QLSV2008")
        {
            Database.SetInitializer<QLSV2008>(new CreateData());
        }
        private static QLSV2008 instance;

        public virtual DbSet<SV> SVs { get; set; }
        public virtual DbSet<LSH> LSHes { get; set; }
        public static QLSV2008 Instance
        {
            get
            {
                if (instance == null) instance = new QLSV2008();
                return instance;
            }
            private set
            {

            }
        }
    }
}
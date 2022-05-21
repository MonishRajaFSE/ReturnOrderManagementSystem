using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComponentProcessingMicroservice.Entities;

namespace ComponentProcessingMicroservice.DBContexts
{
    public class DBContext : DbContext
    {
		public DbSet<User> Users { get; set; }
		public DbSet<MasterTable> MasterTable { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(

			//	$"Server=returnordermanagementsystem.database.windows.net\\SQLEXPRESS;" +
			//$"Database=ReturnOrderManagementSystem;" +
			//$"Trusted_Connection=True;" +
			//$"MultipleActiveResultSets=true;" +
			//$"ConnectRetryCount=0");

			$"Server = tcp:returnordermanagementsystem.database.windows.net,1433;" +
				$"Initial Catalog = ReturnOrderManagementSystem;" +
				$"Persist Security Info = False;" +
				$"User ID = dba;" +
				$"Password =ROMS@123;" +
				$"MultipleActiveResultSets = False;" +
				$"Encrypt = True;" +
				$"TrustServerCertificate = False;" +
				$"Connection Timeout = 30;");
		}
	}
}
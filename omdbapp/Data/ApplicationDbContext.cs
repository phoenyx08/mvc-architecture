using System;
 using System.Collections.Generic;
 using System.Text;
 using Microsoft.EntityFrameworkCore;
 using omdbapp.Models;

 namespace omdbapp.Data
 {
     public class ApplicationDbContext : DbContext
     {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
         {
         }
         public virtual DbSet<MovieDetailsModel> MovieDetailsModels {get; set;}
         public virtual DbSet<RatingItem> RaingItems { get; set; }
         
     }
 }
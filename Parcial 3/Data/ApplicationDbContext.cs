
using Microsoft.EntityFrameworkCore;
using OficinaPasaportesWeb.Models;

namespace OficinaPasaportesWeb.Data {
public class ApplicationDbContext : DbContext {
 public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
 public DbSet<Applicant> Applicants => Set<Applicant>();
 public DbSet<PassportRequest> PassportRequests => Set<PassportRequest>();
 public DbSet<RequestStatus> RequestStatuses => Set<RequestStatus>();
 public DbSet<Passport> Passports => Set<Passport>();
}}

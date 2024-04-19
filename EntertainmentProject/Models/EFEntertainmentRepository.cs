using System;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentProject.Models
{
    public class EFEntertainmentRepository : IEntertainmentRepository
    {
        private EntertainmentDbContext _context;
        
        public EFEntertainmentRepository (EntertainmentDbContext context)
        {
            _context = context;
        }

        public List<Entertainer> Entertainers => _context.Entertainers.ToList ();


        public void AddEntertainer(Entertainer entertainer)
        {
            _context.Entertainers.Add(entertainer);
            _context.SaveChanges();
        }
        public void UpdateEntertainer(Entertainer entertainer)
        {
            _context.Entertainers.Update(entertainer);
            _context.SaveChanges();
        }
        public void DeleteEntertainer(Entertainer entertainer)
        {
            _context.Entertainers.Remove(entertainer);
            _context.SaveChanges();

        }
    }
}


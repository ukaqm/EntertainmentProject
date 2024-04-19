using System;

namespace EntertainmentProject.Models
{
    public interface IEntertainmentRepository
    {
        List<Entertainer> Entertainers { get; }

        public void AddEntertainer(Entertainer entertainer);
        public void UpdateEntertainer(Entertainer entertainer);
        public void DeleteEntertainer(Entertainer entertainer);
    }
}


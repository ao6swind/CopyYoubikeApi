using Models;
using Services;
using System;

namespace BatchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            YouBikeSiteService youBikeSiteService = new YouBikeSiteService();
            youBikeSiteService.Backup();
        }
    }
}

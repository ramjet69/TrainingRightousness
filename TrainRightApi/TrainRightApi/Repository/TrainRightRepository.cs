using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TrainRightApi.DataContext;
using TrainRightApi.Models;

namespace TrainRightApi.Repository
{
    public class TrainRightRepository : ITrainRightRepository
    {
        private TrainRightContext _context;

        public TrainRightRepository(TrainRightContext context)
        {
            _context = context;
        }

        public IEnumerable<SinCategory> GetAllSinCategories()
        {
            try
            {
                //SinSubCats included because model defines relationship??
                return _context.SinCategory.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SinCategory GetSinCategorybyId(int id)
        {
            try
            {
                return _context.SinCategory.First(sc => sc.Id==id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SinSubCategory GetSinSubCategoriesbyId(int catid)
        {
            try
            {
                return _context.SinSubCategory.First(q => q.Id == catid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<SinSubCategory> GetAllSubCategories()
        {
            try
            {
                return _context.SinSubCategory.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SinSectionHeader GetSinSectionHeader(int sinsubid)
        {
            try
            {
                return _context.SinSectionHeader.First(sc => sc.SubCatId == sinsubid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<SinSection> GetSinSectionTabs()
        {
            try
            {
                return _context.SinSection;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<SinSubCatCrossRef> GetSeeAlso(string subcat)
        {
            try
            {
                int subid = ReturnSubCatId(subcat);
                return _context.SinSubCatCrossRef.Where(s => s.SubCatId == subid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<InfoCommands> GetInfoCommands(string subcat)
        {
            int subid = this.ReturnSubCatId(subcat);
            return _context.InfoCommands.Where(i => i.SubCatId == subid);
        }

        public IEnumerable<InfoCommands> GetInfoCommands(int subcatid)
        {
            return _context.InfoCommands.Where(i => i.SubCatId == subcatid);
        }

        public IEnumerable<WhatHappens> GetWhatHappens(string subcat)
        {
            int subid = ReturnSubCatId(subcat);
            return _context.WhatHappens.Where(i => i.SubCatId == subid);
        }

        public IEnumerable<Repentance> GetRepentance(string subcat)
        {
            int subid = ReturnSubCatId(subcat);
            return _context.Repentance.Where(i => i.SubCatId == subid);
        }

        public IEnumerable<InfoCommands> UpdateInfoCommands(InfoCommands command)
        {
            InfoCommands infoCommands = _context.InfoCommands.Where(i => i.SubCatId == command.SubCatId).FirstOrDefault();
            infoCommands.Id = command.Id;
            infoCommands.SubCatId = command.SubCatId;
            infoCommands.Verse = command.Verse;
            infoCommands.VerseCommand = command.VerseCommand;
            infoCommands.VerseInformation = command.VerseCommand;
            infoCommands.VerseNumber = command.VerseNumber;
            _context.SaveChanges();
            return GetInfoCommands(infoCommands.SubCatId);
        }

        public IEnumerable<InfoCommands> CreateInfoCommands(InfoCommands command)
        {
            InfoCommands infoCommands = _context.InfoCommands.Add(command);
            _context.SaveChanges();
            return GetInfoCommands(infoCommands.SubCatId);
        }

        private int ReturnSubCatId(string subcat)
        {
            return _context.SinSubCategory.First(a => a.SubCategoryName == subcat).Id;
        }

        public bool SaveAll()
        {
            return this._context.SaveChanges() > 0;
        }
    }
}
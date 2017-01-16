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

        public IEnumerable<SinCategory> GetAllSinCategories(bool includesubs)
        {
            try
            {
                //if (!includesubs)
                return _context.SinCategory.ToList();
                //return ((IEnumerable<SinCategory>)_context.SinCategory).ToList();
                //return ((IEnumerable<SinCategory>)QueryableExtensions.Include(_context.SinCategory, (i => i.SinSubCategory))).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SinCategory GetSinCategorybyId(int id, bool includesubs)
        {
            try
            {
                //if (includesubs)
                    return _context.SinCategory.First(sc => sc.Id==id);
                

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<SinSubCategory> GetSinSubCategorisbyCatId(int catid)
        {
            try
            {
                return (IEnumerable<SinSubCategory>)((IQueryable<SinSubCategory>)this._context.SinSubCategory).Where<SinSubCategory>((Expression<Func<SinSubCategory, bool>>)(q => q.SinCategoryId == catid));
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
                return (IEnumerable<SinSubCategory>)((IEnumerable<SinSubCategory>)this._context.SinSubCategory).ToList<SinSubCategory>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SinSubCategory GetSinSubCategoriesbyId(int id)
        {
            try
            {
                return ((IQueryable<SinSubCategory>)this._context.SinSubCategory).First<SinSubCategory>((Expression<Func<SinSubCategory, bool>>)(sc => sc.Id == id));
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
                return ((IQueryable<SinSectionHeader>)this._context.SinSectionHeader).First<SinSectionHeader>((Expression<Func<SinSectionHeader, bool>>)(sc => sc.SubCatId == sinsubid));
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
                return (IEnumerable<SinSection>)this._context.SinSection;
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
                int subid = this.ReturnSubCatId(subcat);
                return (IEnumerable<SinSubCatCrossRef>)((IQueryable<SinSubCatCrossRef>)this._context.SinSubCatCrossRef).Where<SinSubCatCrossRef>((Expression<Func<SinSubCatCrossRef, bool>>)(s => s.SubCatId == subid));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<InfoCommands> GetInfoCommands(string subcat)
        {
            int subid = this.ReturnSubCatId(subcat);
            return (IEnumerable<InfoCommands>)((IQueryable<InfoCommands>)this._context.InfoCommands).Where<InfoCommands>((Expression<Func<InfoCommands, bool>>)(i => i.SubCatId == subid));
        }

        public IEnumerable<InfoCommands> GetInfoCommands(int subcatid)
        {
            return (IEnumerable<InfoCommands>)((IQueryable<InfoCommands>)this._context.InfoCommands).Where<InfoCommands>((Expression<Func<InfoCommands, bool>>)(i => i.SubCatId == subcatid));
        }

        public IEnumerable<WhatHappens> GetWhatHappens(string subcat)
        {
            int subid = this.ReturnSubCatId(subcat);
            return (IEnumerable<WhatHappens>)((IQueryable<WhatHappens>)this._context.WhatHappens).Where<WhatHappens>((Expression<Func<WhatHappens, bool>>)(i => i.SubCatId == subid));
        }

        public IEnumerable<Repentance> GetRepentance(string subcat)
        {
            int subid = this.ReturnSubCatId(subcat);
            return (IEnumerable<Repentance>)((IQueryable<Repentance>)this._context.Repentance).Where<Repentance>((Expression<Func<Repentance, bool>>)(i => i.SubCatId == subid));
        }

        public IEnumerable<InfoCommands> UpdateInfoCommands(InfoCommands command)
        {
            InfoCommands infoCommands = ((IQueryable<InfoCommands>)this._context.InfoCommands).Where<InfoCommands>((Expression<Func<InfoCommands, bool>>)(i => i.SubCatId == command.SubCatId)).FirstOrDefault<InfoCommands>();
            infoCommands.Id = command.Id;
            infoCommands.SubCatId = command.SubCatId;
            infoCommands.Verse = command.Verse;
            infoCommands.VerseCommand = command.VerseCommand;
            infoCommands.VerseInformation = command.VerseCommand;
            infoCommands.VerseNumber = command.VerseNumber;
            this._context.SaveChanges();
            return this.GetInfoCommands(infoCommands.SubCatId);
        }

        public IEnumerable<InfoCommands> CreateInfoCommands(InfoCommands command)
        {
            InfoCommands infoCommands = this._context.InfoCommands.Add(command);
            this._context.SaveChanges();
            return this.GetInfoCommands(infoCommands.SubCatId);
        }

        private int ReturnSubCatId(string subcat)
        {
            return ((IQueryable<SinSubCategory>)this._context.SinSubCategory).First<SinSubCategory>((Expression<Func<SinSubCategory, bool>>)(a => a.SubCategoryName == subcat)).Id;
        }

        public bool SaveAll()
        {
            return this._context.SaveChanges() > 0;
        }
    }
}
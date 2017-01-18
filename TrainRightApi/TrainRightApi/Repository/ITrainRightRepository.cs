using System.Collections.Generic;
using TrainRightApi.Models;

namespace TrainRightApi.Repository
{
    public interface ITrainRightRepository
    {

        IEnumerable<SinCategory> GetAllSinCategories();

        SinCategory GetSinCategorybyId(int id);

        IEnumerable<SinSubCategory> GetAllSubCategories();

        IEnumerable<SinSubCategory> GetSinSubCategoriesbyId(int id);

        SinSectionHeader GetSinSectionHeader(int sinsubid);

        IEnumerable<SinSection> GetSinSectionTabs();

        IEnumerable<SinSubCatCrossRef> GetSeeAlso(string subcat);

        IEnumerable<InfoCommands> GetInfoCommands(string subcat);

        IEnumerable<InfoCommands> UpdateInfoCommands(InfoCommands command);

        IEnumerable<InfoCommands> CreateInfoCommands(InfoCommands command);

        IEnumerable<WhatHappens> GetWhatHappens(string subcat);

        IEnumerable<Repentance> GetRepentance(string subcat);

        bool SaveAll();



    }
}
using EFPFanFic.Business.Scapers.PageScrapers;
using EFPFanFic.UI.Selectors.CategorySelector.ViewModels.DTO;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels.DTO;
using EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels;
using EFPFanFic.Business.Scapers.Entities;

namespace EFPFanFic.Business.Scapers
{
    public class ScrapersManager
    {
        // Scrapers
        private readonly MainPageScraper _mainPageScraper;
        private readonly CategoryPageScraper _categoryPageScraper;
        private readonly FanFicsPageScraper _fanFicsPageScraper;
        
        public ScrapersManager()
        {

            WebClient webClient = new WebClient();
            HtmlDocument decoder = new HtmlDocument();

            _mainPageScraper = new MainPageScraper(webClient, decoder);
            _categoryPageScraper = new CategoryPageScraper(webClient, decoder);
            _fanFicsPageScraper = new FanFicsPageScraper(webClient, decoder);
        }

        public ObservableCollection<CategoryItemDTO> GetFanFicCategories()
        {
            return _mainPageScraper.GetFanFicCategories();
        }

        public ObservableCollection<SubCategoryItemDTO> GetFanFicSubCategories(string SubCategoryUri)
        {
            if (SubCategoryUri != string.Empty)
                return _categoryPageScraper.GetFanFicSubCategories(SubCategoryUri);
            else
                return new ObservableCollection<SubCategoryItemDTO>();
        }

        public ObservableCollection<FanFicItemViewModel> GetFanFicStories(string fanFicsUri, int page)
        {
            if (fanFicsUri != string.Empty)
                return _fanFicsPageScraper.GetFanFicStories(fanFicsUri, page);
            else
                return new ObservableCollection<FanFicItemViewModel>();
        }

        public ObservableCollection<FanFicItemViewModel> GetFanFicStories(string fanFicsUri, int page, string rating, string genre, string storyLength, 
            string storyStatus, string coupleType, string character1, string character2, string couple, string context, string note, string warn, 
            string excludeNote, string excludeWarn)
        {
            if (fanFicsUri != string.Empty)
                return _fanFicsPageScraper.GetFanFicStories(fanFicsUri, page, rating, genre, storyLength, storyStatus, coupleType, character1, 
                    character2, couple, context, note, warn, excludeNote, excludeWarn);
            else
                return new ObservableCollection<FanFicItemViewModel>();
        }

        public int GetFanFicPages()
        {
            return _fanFicsPageScraper.TotalPages;
        }

        public List<EntityBase> GetRatingOptions() { return _fanFicsPageScraper.RatingOptions; }
        public List<EntityBase> GetGenresOptions() { return _fanFicsPageScraper.GenresOptions; }
        public List<EntityBase> GetStoryLengthOptions() { return _fanFicsPageScraper.StoryLengthOptions; }
        public List<EntityBase> GetStoryStatusOptions() { return _fanFicsPageScraper.StoryStatusOptions; }
        public List<EntityBase> GetCoupleTypesOptions() { return _fanFicsPageScraper.CoupleTypesOptions; }
        public List<EntityBase> GetCharactersOptions() { return _fanFicsPageScraper.CharactersOptions; }
        public List<EntityBase> GetCouplesOptions() { return _fanFicsPageScraper.CouplesOptions; }
        public List<EntityBase> GetContextOptions() { return _fanFicsPageScraper.ContextOptions; }
        public List<EntityBase> GetNotesOptions() { return _fanFicsPageScraper.NotesOptions; }
        public List<EntityBase> GetWarnsOptions() { return _fanFicsPageScraper.WarnsOptions; }

        public FullStoryData GetFanFicFullStory(string fanFicUri)
        {
            return _fanFicsPageScraper.GetFanFicFullStory(fanFicUri);
        }

        internal string GetFanFicFullStoryUrl(string uri)
        {
            return _fanFicsPageScraper.GetFanFicFullStoryUrl(uri);
        }
    }
}

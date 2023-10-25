using Application.ViewModels;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EpisodeServices
    {
        public int count = 0;
        public int pages = 0;
        private EpisodeRepository repository;

        public EpisodeServices()
        {
            repository = new();
        }

        public async Task getInfo()
        {
            int[] info = await repository.getInfo();
            count = info[0];
            pages = info[1];
        }

        public async Task<List<EpisodeViewModel>> getAllEpisodes(int pages)
        {
            List<Episode> data = await repository.getAll(pages);
            List<EpisodeViewModel> episodes = new();

            foreach (var item in data)
            {
                EpisodeViewModel episode = new();
                episode.id = item.id;
                episode.name = item.name;
                episode.air_date = item.air_date;
                episode.episode = item.episode;
                episodes.Add(episode);
            }
            return episodes;
        }

        public async Task<List<EpisodeViewModel>> filterEpisodes(string search)
        {
            List<Episode> data = await repository.filter(search);
            List<EpisodeViewModel> searchEpisodes = new();

            foreach (var item in data)
            {
                EpisodeViewModel episode = new();
                episode.id = item.id;
                episode.name = item.name;
                episode.air_date = item.air_date;
                episode.episode = item.episode;
                searchEpisodes.Add(episode);
            }
            return searchEpisodes;
        }
    }
}

using SliderEntity=ecommerce.Domain.Entities.Slider;
using Repositories.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.infrutructure;
using ecommerce_shared.File.S3;
using ecommerce_shared.Constant;
using ecommerce_shared.File;
using Repositories.Slider.Operations;
using ecommerce.Dto.Results.Admin;
using Microsoft.AspNetCore.Hosting;
using ecommerce.Domain.Entities;
using ecommerce_shared.Enums;
using Nest;
using ecommerce.Domain.ElasticSearch;

namespace Repositories.Slider
{
    public class SliderRepository : GenericRepository<SliderEntity> ,ISliderRepository
    {

        public IStorageService StorageService;
        public IElasticClient ElasticClient;


        public IWebHostEnvironment WebHostEnvironment;

        public SliderRepository(IElasticClient ElasticClient,IWebHostEnvironment WebHostEnvironment,ApplicationDbContext DbContext, IStorageService StorageService) : base(DbContext)
        {
            this.WebHostEnvironment = WebHostEnvironment;
            this.StorageService = StorageService;
            this.ElasticClient = ElasticClient; 

        }

        public async Task<SliderEntity> Store(string url, int rank)
        {
            try
            {

                ImageResponse image = await StorageService.OptimizeFile(url, FolderName.Slider);
                var Slider = new SliderEntity();
                Slider.Rank = rank;
                Slider.Url = image.Url;
                Slider.ResizedUrl = image.resized;
                Slider.Hash = image.hash;
                DbContext.Sliders.Add(Slider);
                DbContext.SaveChanges();
                ElasticClient.AddEntity(Slider, ElasticSearchIndexName.slider);
                return Slider;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
            




        }


        public List<AddSliderResponse> GetAll()
        {

            return DbContext.Sliders.Select(SliderStoreQuery.ToSliderResponse).ToList();

        }


        public bool IsExists(Guid Id)
        {


            return DbContext.Sliders.Any(x=>x.Id==Id);

        }

        public AddSliderResponse Get(Guid id)
        {

            return DbContext.Sliders
                .Select(SliderStoreQuery.ToSliderResponse)
                .FirstOrDefault(x => x.Id == id);

        }

        public bool IsUniqueRank(Guid Id, int Rank)
        {

            return !DbContext.Sliders.Any(x=>x.Id!=Id&&x.Rank==Rank);

        }



        public bool IsValidLogo(Guid Id, string logo)
        {

            if (FileExtensionLocal.IsImageExists(logo, WebHostEnvironment.WebRootPath))
            {

                return true;

            }

            var brand = DbContext.Sliders.FirstOrDefault(x => x.Id == Id);
            if (brand == null)
            {

                return false;
            }
            if (brand.Url == logo)
            {
                return true;
            }

            return false;




        }


        public async Task<AddSliderResponse> Update(Guid id, string url, int rank)
        {
            SliderEntity DBSlider= DbContext.Sliders.FirstOrDefault(b => b.Id ==id);
            if (url == DBSlider.Url)
            {

                DBSlider.Rank = rank;
                DbContext.SaveChanges();
            }
            else
            {
                ImageResponse image = await StorageService.OptimizeFile(url, FolderName.Slider);
                DBSlider.Rank= rank;
                DBSlider.Url = image.Url;
                DBSlider.ResizedUrl = image.resized;
                DBSlider.Hash = image.hash;
                DbContext.SaveChanges();

            }
            ElasticClient.Update<SliderEntity>(DBSlider, ElasticSearchIndexName.slider);
            return SliderStoreQuery.ToSliderResponse.Compile()(DBSlider);




        }


        public bool Delete(Guid id)
        {
            var slider= new SliderEntity { Id = id };
            DbContext.Sliders.Remove(slider);
            ElasticClient.Delete(slider, ElasticSearchIndexName.slider);
            return true;
        }



    }
}

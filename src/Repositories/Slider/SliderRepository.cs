using SliderEntity = ecommerce.Domain.Entities.Slider.Slider;
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
using ecommerce_shared.Enums;
using ecommerce_shared.Pagination;
using Nest;
using ecommerce.Domain.ElasticSearch;
using ecommerce.Domain.Entities.Slider;

namespace Repositories.Slider
{
    public class SliderRepository : GenericRepository<SliderEntity>, ISliderRepository
    {

        public IStorageService StorageService;
        public IElasticClient ElasticClient;


        public IWebHostEnvironment WebHostEnvironment;

        public SliderRepository(IElasticClient ElasticClient, IWebHostEnvironment WebHostEnvironment, ApplicationDbContext DbContext, IStorageService StorageService) : base(DbContext)
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
<<<<<<< HEAD
                //ElasticClient.AddEntity(Slider, ElasticSearchIndexName.slider);
=======
                // ElasticClient.AddEntity(Slider, ElasticSearchIndexName.slider);
>>>>>>> ed
                return Slider;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }





        }


        public  PageList<AddSliderResponse> GetAll(int? PageNumber,int? PageSize)
        {

            return  DbContext.Sliders.OrderBy(x=>x.Rank).Select(SliderStoreQuery.ToSliderResponse).ToPagedList(PageNumber,PageSize);

            
        }


        public bool IsExists(SliderId Id)
        {


            return DbContext.Sliders.Any(x => x.Id == Id);

        }

        public AddSliderResponse Get(SliderId id)
        {

            return DbContext.Sliders
                .Select(SliderStoreQuery.ToSliderResponse)
                .First(x => x.Id == id);

        }

        public bool IsUniqueRank(SliderId Id, int Rank)
        {

            return !DbContext.Sliders.Any(x => x.Id != Id && x.Rank == Rank);

        }



        public bool IsValidLogo(SliderId Id, string logo)
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


        public async Task<AddSliderResponse> Update(SliderId id, string url, int rank)
        {
            SliderEntity DBSlider = DbContext.Sliders.FirstOrDefault(b => b.Id == id);
            if (url == DBSlider.Url)
            {

                DBSlider.Rank = rank;
                DbContext.SaveChanges();
            }
            else
            {
                ImageResponse image = await StorageService.OptimizeFile(url, FolderName.Slider);
                DBSlider.Rank = rank;
                DBSlider.Url = image.Url;
                DBSlider.ResizedUrl = image.resized;
                DBSlider.Hash = image.hash;
                DbContext.SaveChanges();

            }
<<<<<<< HEAD
            //ElasticClient.Update<SliderEntity>(DBSlider, ElasticSearchIndexName.slider);
=======
            // ElasticClient.Update<SliderEntity>(DBSlider, ElasticSearchIndexName.slider);
>>>>>>> ed
            return SliderStoreQuery.ToSliderResponse.Compile()(DBSlider);




        }


        public bool Delete(SliderId id)
        {
            var slider = new SliderEntity { Id = id };
            DbContext.Sliders.Remove(slider);
<<<<<<< HEAD
            DbContext.SaveChanges();
            //ElasticClient.Delete(slider, ElasticSearchIndexName.slider);
=======
            // ElasticClient.Delete(slider, ElasticSearchIndexName.slider);
>>>>>>> ed
            return true;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public class Repository : IRepository
    {
        private readonly DigitalRegistryContext digitalRegistryContext;
        public Repository(DigitalRegistryContext context)
        {
            digitalRegistryContext = context;

        }

        public bool SaveResults(RootObject root)
        {
            bool anyNewRecordsInserted = false;
            foreach (Result c in root.results)
            {

                digitalRegistryContext.Result.Add(c);
                anyNewRecordsInserted = true;


            }
            digitalRegistryContext.SaveChanges();
            return true;

        }

        public bool SaveMobileApps(RootObject2 root)
        {
            bool anyNewRecordsInserted = false;
            MobileApp mobileApp = new MobileApp();
            foreach (Result2 c in root.results)
            {

                mobileApp = convert(c);

                digitalRegistryContext.mobileApps.Add(mobileApp);

                anyNewRecordsInserted = true;

            }
            digitalRegistryContext.SaveChanges();
            return true;


        }
        public bool SaveSocial(RootObject3 root)
        {
            bool anyNewRecordsInserted = false;
            SocialMedia socialMedia = new SocialMedia();
            foreach (Result3 c in root.results)
            {

                socialMedia = convertSocial(c);
                digitalRegistryContext.socialMedias.Add(socialMedia);

                anyNewRecordsInserted = true;

            }
            digitalRegistryContext.SaveChanges();
            return true;
        }

        public SocialMedia convertSocial(Result3 social) {
            SocialMedia socialMedia = new SocialMedia();
            socialMedia.id = social.id;
            socialMedia.language = social.language;
            socialMedia.long_description = social.long_description;
            socialMedia.organization = social.organization;
            socialMedia.service_display_name = social.service_display_name;
            socialMedia.short_description = social.short_description;
            socialMedia.service_url = social.service_url;
            return socialMedia;




        }


        public MobileApp convert(Result2 result2)
        {
            MobileApp mobileApp = new MobileApp();
            mobileApp.name = result2.name;
            mobileApp.id = result2.id;
            mobileApp.language = result2.language;
            mobileApp.long_description = result2.long_description;
            mobileApp.short_description = result2.short_description;
            return mobileApp;



        }

        public bool getCount()
        {

            int var;
            var = digitalRegistryContext.Result.Count();
            if (var > 0)
                return false;
            else
                return true;


        }

        public bool getCount2()
        {
            int var;
            var = digitalRegistryContext.mobileApps.Count();
            if (var > 0)
                return false;
            else
                return true;
        }


        public bool getSocialData() {
            int var;
            var = digitalRegistryContext.socialMedias.Count();
            if (var > 0)
                return false;
            else
                return true;


        }

        public bool getTagsData() {
            int var;
            var = digitalRegistryContext.Tags.Count();
            if (var > 0)
                return false;
            else
                return true;

       }

        public bool saveTags(TagsRoot tagsRoot) {

            bool anyNewRecordsInserted = false;
            
            Tags tags = new Tags();
            foreach (Tags c in tagsRoot.results)
            {

               
                digitalRegistryContext.Tags.Add(c);

                anyNewRecordsInserted = true;

            }
            digitalRegistryContext.SaveChanges();
            return true;
        }


      

     

    }
}



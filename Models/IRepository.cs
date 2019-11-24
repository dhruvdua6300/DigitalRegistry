using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRegistry.Models
{
    public interface IRepository
    {
        bool SaveResults(RootObject root);
        bool getCount();

        bool getCount2();

        bool SaveMobileApps(RootObject2 root);

        bool SaveSocial(RootObject3 root);

        bool getSocialData();

        bool getTagsData();

        bool saveTags(TagsRoot tagsRoot);

        
    }
}

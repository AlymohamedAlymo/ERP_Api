using System.Linq;
using System.Reflection;

namespace ERP_Data.Utilities
{
    public static class MapProperties
    {
        public static void Map<TFirstType, TSeconType>(TFirstType SourceObject, TSeconType DesitnationObject, params string[] Names)
        {
            DesitnationObject.GetType().GetProperties().ToList()
                .ForEach(delegate (PropertyInfo Info)
                {
                    if (!Names.Contains(Info.Name))
                    {
                        if (SourceObject.GetType().GetProperties().Any((PropertyInfo Object) => Object.Name == Info.Name))
                        {
                            Info.SetValue(DesitnationObject, (from a in SourceObject.GetType().GetProperties()
                                                              where a.Name == Info.Name
                                                              select a).FirstOrDefault().GetValue(SourceObject));
                        }
                    }
                });
        }


    }
}

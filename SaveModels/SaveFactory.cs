using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18.SaveModels
{
    internal class SaveFactory
    {
        private List<ISaver> saverList = [];

        public SaveFactory()
        {
            AddSaver(new JsonSaver());
            AddSaver(new XmlSaver());
        }
        private void AddSaver(ISaver saver) => saverList.Add(saver);
        public ISaver GetSaver(string saverName)
        {
            return saverList
                .Where(saver => saver.GetType().Name == saverName)
                .First();
        }

        public List<KeyValuePair<string, ISaver>> GetSaversDic()
        {
            return saverList
                .Select(saver => new KeyValuePair<string, ISaver>(saver.GetType().Name, saver))
                .ToList();
        }
    }
}

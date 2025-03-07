namespace Pg.SfGridCustomButtons.Client.Data
{
    public class SectionRepository : ISectionRepository
    {
        private List<Section> _sections; 
        public SectionRepository() 
        {
            _sections = new List<Section>()
            {
                new Section() {Id = 1, Name = "Section 1", Description = "Description 1"},
                new Section() {Id = 2, Name = "Section 2", Description = "Description 2"},
                new Section() {Id = 3, Name = "Section 3", Description = "Description 3"},
                new Section() {Id = 4, Name = "Section 4", Description = "Description 4"},
                new Section() {Id = 5, Name = "Section 5", Description = "Description 5"}
            }; 
        }

        public List<Section> GetAll()
        {
            return new List<Section>(_sections);
        }

        public Section Insert(Section section)
        {
            var lastId = _sections.Max(x => x.Id);
            section.Id = lastId + 1; 
            _sections.Add(section);
            return section; 
        }

        public void Update(Section section)
        {
            _sections[_sections.FindIndex(x => x.Id == section.Id)] = section;
        }
        public void Delete(int id)
        {
            var section = this._sections.Find(x => x.Id == id);
            if (section != null)
                this._sections.Remove(section); 
        }
    }
}

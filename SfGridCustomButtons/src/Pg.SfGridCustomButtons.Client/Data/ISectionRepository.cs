namespace Pg.SfGridCustomButtons.Client.Data
{
    public interface ISectionRepository
    {
        List<Section> GetAll();

        Section Insert(Section section);

        void Update(Section section);

        void Delete(int id);
    }
}

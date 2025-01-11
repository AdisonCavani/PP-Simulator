namespace Simulator.Maps;

public interface IMappable
{
    string Go(Direction direction);
    void Initialize(Map map, Point position, bool initializeMap);
    void ClearMap();
}

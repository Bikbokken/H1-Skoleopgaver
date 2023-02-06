public class Identity
{
    private string _identity;
    private string _mask;
    private string _costume;
    private string _moral;
    private List<Abilities> _abilities;

}

public class Villain
{
    private Identity _identity;
    private List<SuperHero> _enemies;
}
public class SuperHero
{
    private Identity _identity;
    private List<Villain> _enemies;
}

public class Abilities
{
    private string _name;
}


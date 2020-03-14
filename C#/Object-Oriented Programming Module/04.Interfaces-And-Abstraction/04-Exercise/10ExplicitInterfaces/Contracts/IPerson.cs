namespace ExplicitInterfaces.Contracts
{
    interface IPerson
    {
        string Name { get; }

        int Age { get; }

        string GetName();
    }
}

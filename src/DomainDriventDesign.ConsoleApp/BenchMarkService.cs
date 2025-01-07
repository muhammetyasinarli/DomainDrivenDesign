using BenchmarkDotNet.Attributes;

[MemoryDiagnoser] // Hafıza tahsisini de analiz eder.
public class BenchMarkService
{
    private Test1 _test1a;
    private Test1 _test1b;
    private Test2 _test2a;
    private Test2 _test2b;

    [GlobalSetup]
    public void Setup()
    {
        int id = 100;
        _test1a = new Test1 { Id = id };
        _test1b = new Test1 { Id = id };
        _test2a = new Test2 { Id = id };
        _test2b = new Test2 { Id = id };
    }

    [Benchmark(Baseline = true)]
    public bool Equals()
    {
        return _test1a.Equals(_test1b);
    }

    [Benchmark]
    public bool IEquatable()
    {
        return _test2a.Equals(_test2b);
    }
}

public class Test1
{
    public int Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj is not Test1 entity) return false;

        if (obj.GetType() != GetType()) return false;

        return entity.Id == Id;
    }
}

public class Test2 : IEquatable<Test2>
{
    public int Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj is not Test2 entity) return false;

        if (obj.GetType() != GetType()) return false;

        return entity.Id == Id;
    }

    public bool Equals(Test2? other)
    {
        if (other is null) return false;

        if (other.GetType() != GetType()) return false;

        return other.Id == Id;
    }
}

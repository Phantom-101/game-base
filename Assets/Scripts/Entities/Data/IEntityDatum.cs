public interface IEntityDatum {

    /// <summary>
    /// This function returns the entity to which this datum is attached.
    /// </summary>
    /// <returns>An instance of a class implementing IEntity to which this datum is attached.</returns>
    IEntity GetPossessingEntity ();

    /// <summary>
    /// This function will be called upon initialization of this datum.
    /// </summary>
    void OnInitialize ();

    /// <summary>
    /// This function will be called every update tick.
    /// </summary>
    void OnUpdate ();

    /// <summary>
    /// This function determines whether or not this datum collides with <paramref name="datum"/>.
    /// </summary>
    /// <param name="datum">The datum to be checked for collision against.</param>
    /// <returns>A boolean denoting whether or not this datum collides with <paramref name="datum"/></returns>
    bool Collides (IEntityDatum datum);

}

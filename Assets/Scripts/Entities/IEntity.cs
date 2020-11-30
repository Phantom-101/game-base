using System.Collections.Generic;

/// <summary>
/// All entities should implement <c>IEntity</c>.
/// </summary>
public interface IEntity {

    /// <summary>
    /// This function returns the name of the entity. Note that an entity's name may not be the same as its identifier.
    /// </summary>
    /// <returns>A string containing the entity's name.</returns>
    string GetName ();

    /// <summary>
    /// This function returns the identifier of the entity. Note that an entity's identifier cannot be manually assigned and are instead randomly generated. An entity's identifier may not be the same as its name.
    /// </summary>
    /// <returns>A string containing the entity's identifier.</returns>
    string GetIdentifier ();

    /// <summary>
    /// This function returns the entity's superentity, i.e. its parent.
    /// </summary>
    /// <returns>An instance of a class implementing IEntity representing the entity's superentity.</returns>
    IEntity GetSuperEntity ();

    /// <summary>
    /// This function returns the entity's subentities, i.e. its children.
    /// </summary>
    /// <returns>A list of instances of classes implementing IEntity representing the entity's subentities.</returns>
    List<IEntity> GetSubEntities ();

    /// <summary>
    /// This function returns the behaviours attached to the entity.
    /// </summary>
    /// <returns>A list of instances of classes implementing IEntityBehaviour representing the entity's attached behaviours.</returns>
    List<IEntityBehaviour> GetBehaviours ();

    /// <summary>
    /// This function returns a behaviour of type <typeparamref name="T"/> attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the behaviour to return.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be returned.</param>
    /// <returns>A single instance of a class implementing IEntityBehaviour that is currently attached to the entity.</returns>
    IEntityBehaviour GetBehaviour<T> (bool inherited);

    /// <summary>
    /// This function returns all behaviours of type <typeparamref name="T"/> attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the behaviours to return.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be returned.</param>
    /// <returns>Multiple instance of classes implementing IEntityBehaviour that is currently attached to the entity.</returns>
    List<IEntityBehaviour> GetBehaviours<T> (bool inherited);

    /// <summary>
    /// This function checks if <paramref name="behaviour"/> is currently attached to the entity.
    /// </summary>
    /// <param name="behaviour">The behaviour to check for.</param>
    /// <returns>A boolean denoting whether or not <paramref name="behaviour"/> is currently attached to the entity.</returns>
    bool PossessesBehaviour (IEntityBehaviour behaviour);

    /// <summary>
    /// This function checks if a behaviour of type <typeparamref name="T"/> is currently attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of behaviours to check for.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be considered.</param>
    /// <returns>A boolean denoting whether or not a behaviour of type <typeparamref name="T"/> is currently attached to the entity.</returns>
    bool PossessesBehaviour<T> (bool inherited);

    /// <summary>
    /// This function counts the number of behaviours that are currently attached to the entity.
    /// </summary>
    /// <returns>An integer denoting the number of behaviours that are currently attached to the entity.</returns>
    int CountBehaviours ();

    /// <summary>
    /// This function counts the number of behaviours of type <typeparamref name="T"/> that are currently attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of behaviours to check for.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be counted.</param>
    /// <returns>An integer denoting the number of behaviours of type <typeparamref name="T"/> that are currently attached to the entity.</returns>
    int CountBehaviours<T> (bool inherited);

    /// <summary>
    /// This function adds <paramref name="behaviour"/> to the entity.
    /// </summary>
    /// <param name="behaviour">The behaviour to add to the entity.</param>
    /// <returns>A boolean denoting whether or not the behaviour has been added successfully.</returns>
    bool AddBehaviour (IEntityBehaviour behaviour);

    /// <summary>
    /// This function adds a new behaviour of type <typeparamref name="T"/> to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the behaviour to add to the entity.</typeparam>
    /// <returns>A boolean denoting whether or not a new behaviour of type <typeparamref name="T"/> has been added successfully.</returns>
    bool AddBehaviour<T> ();

    /// <summary>
    /// This function removes <paramref name="behaviour"/> from the entity.
    /// </summary>
    /// <param name="behaviour">The behaviour to remove from the entity.</param>
    /// <returns>A boolean denoting whether or not the behaviour has been removed successfully.</returns>
    bool RemoveBehaviour (IEntityBehaviour behaviour);

    /// <summary>
    /// This function removes a behaviour of type <typeparamref name="T"/> from the entity.
    /// </summary>
    /// <typeparam name="T">The type of the behaviour to remove from the entity.</typeparam>
    /// <param name="inherited">Denotes whether or not a behaviour inherited from type <typeparamref name="T"/> should be removed.</param>
    /// <returns>A boolean denoting whether or not a behaviour of type <typeparamref name="T"/> has been removed successfully.</returns>
    bool RemoveBehaviour<T> (bool inherited);

    /// <summary>
    /// This function removes all behaviours of type <typeparamref name="T"/> from the entity.
    /// </summary>
    /// <typeparam name="T">The type of the behaviours to remove from the entity.</typeparam>
    /// <param name="inherited">Denotes whether or not behaviours inherited from type <typeparamref name="T"/> should be removed.</param>
    /// <returns>A boolean denoting whether or not all behaviours of type <typeparamref name="T"/> has been removed successfully.</returns>
    bool RemoveBehaviours<T> (bool inherited);

    /// <summary>
    /// This function returns the data attached to the entity.
    /// </summary>
    /// <returns>A list of instances of classes implementing IEntityDatum representing the entity's attached data.</returns>
    List<IEntityDatum> GetDatum ();

    /// <summary>
    /// This function returns a datum of type <typeparamref name="T"/> attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the datum to return.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be returned.</param>
    /// <returns>A single instance of a class implementing IEntityDatum that is currently attached to the entity.</returns>
    IEntityDatum GetDatum<T> (bool inherited);

    /// <summary>
    /// This function returns all data of type <typeparamref name="T"/> attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the data to return.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be returned.</param>
    /// <returns>Multiple instance of classes implementing IEntityDatum that is currently attached to the entity.</returns>
    List<IEntityDatum> GetData<T> (bool inherited);

    /// <summary>
    /// This function checks if <paramref name="datum"/> is currently attached to the entity.
    /// </summary>
    /// <param name="datum">The datum to check for.</param>
    /// <returns>A boolean denoting whether or not <paramref name="datum"/> is currently attached to the entity.</returns>
    bool PossessesDatum (IEntityDatum datum);

    /// <summary>
    /// This function checks if a datum of type <typeparamref name="T"/> is currently attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of data to check for.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be considered.</param>
    /// <returns>A boolean denoting whether or not a datum of type <typeparamref name="T"/> is currently attached to the entity.</returns>
    bool PossessesDatum<T> (bool inherited);

    /// <summary>
    /// This function counts the number of data that are currently attached to the entity.
    /// </summary>
    /// <returns>An integer denoting the number of data that are currently attached to the entity.</returns>
    int CountData ();

    /// <summary>
    /// This function counts the number of data of type <typeparamref name="T"/> that are currently attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of data to check for.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be counted.</param>
    /// <returns>An integer denoting the number of data of type <typeparamref name="T"/> that are currently attached to the entity.</returns>
    int CountData<T> ();

    /// <summary>
    /// This function adds <paramref name="datum"/> to the entity.
    /// </summary>
    /// <param name="datum">The datum to add to the entity.</param>
    /// <returns>A boolean denoting whether or not the datum has been added successfully.</returns>
    bool AddDatum (IEntityDatum datum);

    /// <summary>
    /// This function adds a new datum of type <typeparamref name="T"/> to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the datum to add to the entity.</typeparam>
    /// <returns>A boolean denoting whether or not a new datum of type <typeparamref name="T"/> has been added successfully.</returns>
    bool AddDatum<T> ();

    /// <summary>
    /// This function removes <paramref name="datum"/> from the entity.
    /// </summary>
    /// <param name="datum">The datum to remove from the entity.</param>
    /// <returns>A boolean denoting whether or not the datum has been removed successfully.</returns>
    bool RemoveDatum (IEntityDatum datum);

    /// <summary>
    /// This function removes a datum of type <typeparamref name="T"/> from the entity.
    /// </summary>
    /// <typeparam name="T">The type of the datum to remove from the entity.</typeparam>
    /// <param name="inherited">Denotes whether or not a datum inherited from type <typeparamref name="T"/> should be removed.</param>
    /// <returns>A boolean denoting whether or not a datum of type <typeparamref name="T"/> has been removed successfully.</returns>
    bool RemoveDatum<T> (bool inherited);

    /// <summary>
    /// This function removes all data of type <typeparamref name="T"/> from the entity.
    /// </summary>
    /// <typeparam name="T">The type of the data to remove from the entity.</typeparam>
    /// <param name="inherited">Denotes whether or not data inherited from type <typeparamref name="T"/> should be removed.</param>
    /// <returns>A boolean denoting whether or not all data of type <typeparamref name="T"/> has been removed successfully.</returns>
    bool RemoveData<T> (bool inherited);

}

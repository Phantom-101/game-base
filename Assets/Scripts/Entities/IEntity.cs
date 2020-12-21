using System.Collections.Generic;

/// <summary>
/// All entities should implement <c>IEntity</c>.
/// </summary>
public interface IEntity {

    /// <summary>
    /// Returns the name of the entity. Note that an entity's name may not be the same as its identifier.
    /// </summary>
    /// <returns>A string containing the entity's name.</returns>
    string GetName ();

    /// <summary>
    /// Sets the name of the entity.
    /// </summary>
    /// <param name="name">The new name of the entity.</param>
    void SetName (string name);

    /// <summary>
    /// Returns the identifier of the entity. Note that an entity's identifier cannot be manually assigned and are instead randomly generated. An entity's identifier may not be the same as its name.
    /// </summary>
    /// <returns>A string containing the entity's identifier.</returns>
    string GetIdentifier ();

    /// <summary>
    /// Returns the entity's parent.
    /// </summary>
    /// <returns>An instance of a class implementing IEntity representing the entity's parent.</returns>
    IEntity GetParent ();

    /// <summary>
    /// Sets the parent of the entity.
    /// </summary>
    /// <param name="parent">The new parent of the entity.</param>
    /// <returns>A boolean denoting whether or not the parent has been set successfully.</returns>
    bool SetParent (IEntity parent);

    /// <summary>
    /// Returns the entity's children.
    /// </summary>
    /// <returns>A list of instances of classes implementing IEntity representing the entity's children.</returns>
    List<IEntity> GetChildren ();

    /// <summary>
    /// Adds <paramref name="child"/> as a child.
    /// </summary>
    /// <param name="child">The entity to add as a child.</param>
    /// <returns>A boolean denoting whether or not <paramref name="child"/> was added as a child successfully.</returns>
    bool AddChild (IEntity child);

    /// <summary>
    /// Removes <paramref name="child"/> as a child;
    /// </summary>
    /// <param name="child">The entity to remove as a child.</param>
    /// <returns>A boolean denoting whether or not <paramref name="child"/> was removed as a child successfully.</returns>
    bool RemoveChild (IEntity child);

    /// <summary>
    /// Returns the behaviours attached to the entity.
    /// </summary>
    /// <returns>A list of instances of classes implementing IEntityBehaviour representing the entity's attached behaviours.</returns>
    List<IEntityBehaviour> GetAllBehaviours ();

    /// <summary>
    /// Returns a behaviour of type <typeparamref name="T"/> attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the behaviour to return.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be returned.</param>
    /// <returns>A single instance of a class implementing IEntityBehaviour that is currently attached to the entity.</returns>
    IEntityBehaviour GetBehaviour<T> (bool inherited) where T : IEntityBehaviour;

    /// <summary>
    /// Returns all behaviours of type <typeparamref name="T"/> attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the behaviours to return.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be returned.</param>
    /// <returns>Multiple instance of classes implementing IEntityBehaviour that is currently attached to the entity.</returns>
    List<IEntityBehaviour> GetAllBehaviours<T> (bool inherited) where T : IEntityBehaviour;

    /// <summary>
    /// Checks if <paramref name="behaviour"/> is currently attached to the entity.
    /// </summary>
    /// <param name="behaviour">The behaviour to check for.</param>
    /// <returns>A boolean denoting whether or not <paramref name="behaviour"/> is currently attached to the entity.</returns>
    bool PossessesBehaviour (IEntityBehaviour behaviour);

    /// <summary>
    /// Checks if a behaviour of type <typeparamref name="T"/> is currently attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of behaviours to check for.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be considered.</param>
    /// <returns>A boolean denoting whether or not a behaviour of type <typeparamref name="T"/> is currently attached to the entity.</returns>
    bool PossessesBehaviour<T> (bool inherited) where T : IEntityBehaviour;

    /// <summary>
    /// Counts the number of behaviours that are currently attached to the entity.
    /// </summary>
    /// <returns>An integer denoting the number of behaviours that are currently attached to the entity.</returns>
    int CountBehaviours ();

    /// <summary>
    /// Counts the number of behaviours of type <typeparamref name="T"/> that are currently attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of behaviours to check for.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be counted.</param>
    /// <returns>An integer denoting the number of behaviours of type <typeparamref name="T"/> that are currently attached to the entity.</returns>
    int CountBehaviours<T> (bool inherited) where T : IEntityBehaviour;

    /// <summary>
    /// Adds <paramref name="behaviour"/> to the entity.
    /// </summary>
    /// <param name="behaviour">The behaviour to add to the entity.</param>
    /// <returns>A boolean denoting whether or not the behaviour has been added successfully.</returns>
    bool AddBehaviour (IEntityBehaviour behaviour);

    /// <summary>
    /// Adds a new behaviour of type <typeparamref name="T"/> to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the behaviour to add to the entity.</typeparam>
    /// <returns>A boolean denoting whether or not a new behaviour of type <typeparamref name="T"/> has been added successfully.</returns>
    bool AddBehaviour<T> () where T : IEntityBehaviour;

    /// <summary>
    /// Removes <paramref name="behaviour"/> from the entity.
    /// </summary>
    /// <param name="behaviour">The behaviour to remove from the entity.</param>
    /// <returns>A boolean denoting whether or not the behaviour has been removed successfully.</returns>
    bool RemoveBehaviour (IEntityBehaviour behaviour);

    /// <summary>
    /// Removes a behaviour of type <typeparamref name="T"/> from the entity.
    /// </summary>
    /// <typeparam name="T">The type of the behaviour to remove from the entity.</typeparam>
    /// <param name="inherited">Denotes whether or not a behaviour inherited from type <typeparamref name="T"/> should be removed.</param>
    /// <returns>A boolean denoting whether or not a behaviour of type <typeparamref name="T"/> has been removed successfully.</returns>
    bool RemoveBehaviour<T> (bool inherited) where T : IEntityBehaviour;

    /// <summary>
    /// Removes all behaviours of type <typeparamref name="T"/> from the entity.
    /// </summary>
    /// <typeparam name="T">The type of the behaviours to remove from the entity.</typeparam>
    /// <param name="inherited">Denotes whether or not behaviours inherited from type <typeparamref name="T"/> should be removed.</param>
    /// <returns>A boolean denoting whether or not all behaviours of type <typeparamref name="T"/> has been removed successfully.</returns>
    bool RemoveAllBehaviours<T> (bool inherited) where T : IEntityBehaviour;

    /// <summary>
    /// Returns the data attached to the entity.
    /// </summary>
    /// <returns>A list of instances of classes implementing IEntityData representing the entity's attached data.</returns>
    List<IEntityData> GetAllData ();

    /// <summary>
    /// Returns a data of type <typeparamref name="T"/> attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the data to return.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be returned.</param>
    /// <returns>A single instance of a class implementing IEntityData that is currently attached to the entity.</returns>
    IEntityData GetData<T> (bool inherited) where T : IEntityData;

    /// <summary>
    /// Returns all data of type <typeparamref name="T"/> attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the data to return.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be returned.</param>
    /// <returns>Multiple instance of classes implementing IEntityData that is currently attached to the entity.</returns>
    List<IEntityData> GetAllData<T> (bool inherited) where T : IEntityData;

    /// <summary>
    /// Checks if <paramref name="data"/> is currently attached to the entity.
    /// </summary>
    /// <param name="data">The data to check for.</param>
    /// <returns>A boolean denoting whether or not <paramref name="data"/> is currently attached to the entity.</returns>
    bool PossessesData (IEntityData data);

    /// <summary>
    /// Checks if a data of type <typeparamref name="T"/> is currently attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of data to check for.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be considered.</param>
    /// <returns>A boolean denoting whether or not a data of type <typeparamref name="T"/> is currently attached to the entity.</returns>
    bool PossessesData<T> (bool inherited) where T : IEntityData;

    /// <summary>
    /// Counts the number of data that are currently attached to the entity.
    /// </summary>
    /// <returns>An integer denoting the number of data that are currently attached to the entity.</returns>
    int CountData ();

    /// <summary>
    /// Counts the number of data of type <typeparamref name="T"/> that are currently attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of data to check for.</typeparam>
    /// <param name="inherited">Denotes whether or not types inherited from type <typeparamref name="T"/> should be counted.</param>
    /// <returns>An integer denoting the number of data of type <typeparamref name="T"/> that are currently attached to the entity.</returns>
    int CountData<T> (bool inherited) where T : IEntityData;

    /// <summary>
    /// Adds <paramref name="data"/> to the entity.
    /// </summary>
    /// <param name="data">The data to add to the entity.</param>
    /// <returns>A boolean denoting whether or not the data has been added successfully.</returns>
    bool AddData (IEntityData data);

    /// <summary>
    /// Adds a new data of type <typeparamref name="T"/> to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the data to add to the entity.</typeparam>
    /// <returns>A boolean denoting whether or not a new data of type <typeparamref name="T"/> has been added successfully.</returns>
    bool AddData<T> () where T : IEntityData;

    /// <summary>
    /// Removes <paramref name="data"/> from the entity.
    /// </summary>
    /// <param name="data">The data to remove from the entity.</param>
    /// <returns>A boolean denoting whether or not the data has been removed successfully.</returns>
    bool RemoveData (IEntityData data);

    /// <summary>
    /// Removes a data of type <typeparamref name="T"/> from the entity.
    /// </summary>
    /// <typeparam name="T">The type of the data to remove from the entity.</typeparam>
    /// <param name="inherited">Denotes whether or not a data inherited from type <typeparamref name="T"/> should be removed.</param>
    /// <returns>A boolean denoting whether or not a data of type <typeparamref name="T"/> has been removed successfully.</returns>
    bool RemoveData<T> (bool inherited) where T : IEntityData;

    /// <summary>
    /// Removes all data of type <typeparamref name="T"/> from the entity.
    /// </summary>
    /// <typeparam name="T">The type of the data to remove from the entity.</typeparam>
    /// <param name="inherited">Denotes whether or not data inherited from type <typeparamref name="T"/> should be removed.</param>
    /// <returns>A boolean denoting whether or not all data of type <typeparamref name="T"/> has been removed successfully.</returns>
    bool RemoveAllData<T> (bool inherited) where T : IEntityData;

}

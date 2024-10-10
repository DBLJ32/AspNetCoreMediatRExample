﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesLab;

public interface IRepo<T> where T : IEntity
{
	void Add(T entity);
	void Remove(T entity);
	void Update(T entity);
	IReadOnlyList<T> Find(Specification<T> specification);
	T GetById(Guid id); //Added GetById method signature
}

public class Repository<T> : IRepo<T> where T : IEntity
{
	private readonly List<T> _data;

	public Repository()
	{
		_data = new List<T>();
	}

	public void Add(T entity)
	{
		_data.Add(entity);
	}

	public void Remove(T entity)
	{
		_data.Remove(entity);
	}

	public void Update(T entity)
	{
		var index = _data.FindIndex(_ => _.Id == entity.Id);
		if (index < 0) // did not find
			return;
		_data[index] = entity;
	}

	public IReadOnlyList<T> Find(Specification<T> specification)
	{
		return _data.Where(specification.ToExpression().Compile()).ToList();
	}

	//Added method GetById to search for id that matches the address you are trying to edit
    public T GetById(Guid id)
    {
        return _data.FirstOrDefault(entry => entry.Id == id);
    }
}
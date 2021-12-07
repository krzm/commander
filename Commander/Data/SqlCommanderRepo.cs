using Commander.Models;

namespace Commander.Data;

public class SqlCommanderRepo : ICommanderRepo
{
	private readonly CommanderContext context;

	public SqlCommanderRepo(
		CommanderContext context)
	{
		this.context = context;
	}

	public IEnumerable<Command> GetCommands()
	{
		return context.Commands.ToList();
	}

	public Command GetCommandById(int id)
	{
		return context.Commands.FirstOrDefault(c => c.Id == id);
	}

	public void CreateCommand(Command cmd)
	{
		if (cmd == null)
			throw new ArgumentNullException(nameof(cmd));

		context.Commands.Add(cmd);
	}

	public void UpdateCommand(Command cmd)
	{
		//Nothing in ef core
	}

	public void DeleteCommand(Command cmd)
	{
		if (cmd == null)
			throw new ArgumentNullException(nameof(cmd));

		context.Commands.Remove(cmd);
	}

	public bool SaveChanges()
	{
		return (context.SaveChanges() >= 0);
	}
}
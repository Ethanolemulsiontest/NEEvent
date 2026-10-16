[System.Serializable]
public class TaskData
{
    public TaskID id;
    public string taskName;
    public bool completed;

    public TaskData(TaskID id, string taskName)
    {
        this.id = id;
        this.taskName = taskName;
        this.completed = false;
    }
}
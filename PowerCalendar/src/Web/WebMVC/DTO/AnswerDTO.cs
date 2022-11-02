namespace WebMVC.DTO
{
    public class AnswerDTO<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }

        public AnswerDTO(T data, string message)
        {
            this.Data = data;
            this.Message = message;
        }
        public AnswerDTO(T data)
        {
            this.Data = data;
        }
    }
}

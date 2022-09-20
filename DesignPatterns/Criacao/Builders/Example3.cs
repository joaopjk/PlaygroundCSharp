namespace Builders
{
  //Fluent builder
  class Email
  {
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
  }

  class EmailBuilder
  {
    private readonly Email _email;
    public EmailBuilder()
    {
      _email = new Email();
    }

    public EmailBuilder To(string destino)
    {
      _email.To = destino;
      return this;
    }

    public EmailBuilder From(string origem)
    {
      _email.From = origem;
      return this;
    }

    public EmailBuilder Subject(string titulo)
    {
      _email.Subject = titulo;
      return this;
    }

    public EmailBuilder Body(string corpo)
    {
      _email.Body = corpo;
      return this;
    }

    public Email CriarEmail()
    {
      return _email;
    }
  }
}
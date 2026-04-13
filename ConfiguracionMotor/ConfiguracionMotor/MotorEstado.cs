public class ConfiguracionMotor
{
    private int _potenciaMaxima; // En vatios al iniciar puede 10000 vatios y su maximo es de 20000 vatios
    private int _temperaturaActual; // En Celsius si esta a mas de 100 se considera sobrecalentamiento  
    private bool _motorEncendido;

    public ConfiguracionMotor(int potenciaMaxima, int temperaturaActual)
    {
        PotenciaMaxima = potenciaMaxima;
        TemperaturaActual = temperaturaActual;
    }

    public void IniciarMotor()
    {
        if (MotorEncendido == true)
        {
            Console.WriteLine("El motor ya está encendido.");
            return;
        }
        else if (TemperaturaActual < -21 || TemperaturaActual > 40)
        {
            throw new InvalidOperationException("La temperatura actual no es adecuada para iniciar el motor. Debe estar entre -21 y 40 grados Celsius.");
        }
        else if (PotenciaMaxima < 1000)
        {
            throw new InvalidOperationException("La potencia máxima del motor es insuficiente para iniciar. Debe ser al menos 1000 vatios.");
        }
        else
        {
            MotorEncendido = true;
            Console.WriteLine("El motor ha sido encendido exitosamente.");
        }
    }

    public void ApagarMotor()
    {
        if (MotorEncendido == false)
        {
            Console.WriteLine("El motor ya está apagado.");
            return;
        }
        else
        {
            MotorEncendido = false;
            Console.WriteLine("El motor ha sido apagado exitosamente.");
        }
    }

    public void AcelerarMotor(int incrementoPotencia) //Por cada 20 vatios de incremento, la temperatura aumenta en 1 grado Celsius
    {
        if (!MotorEncendido)
        {
            throw new InvalidOperationException("El motor debe estar encendido para acelerar.");
        }

        if (incrementoPotencia <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(incrementoPotencia), "El incremento de potencia debe ser un valor positivo.");
        }

        if (PotenciaMaxima + incrementoPotencia > 20000)
        {
            throw new InvalidOperationException("El incremento de potencia excede el límite máximo de 20000 vatios.");
        }

        if (TemperaturaActual + (incrementoPotencia / 20) > 100)
        {
            throw new InvalidOperationException("El incremento de potencia causaría un sobrecalentamiento del motor. La temperatura no debe superar los 100 grados Celsius.");
        }

        int PotenciaNueva = PotenciaMaxima + incrementoPotencia;
        int TemperaturaNueva = TemperaturaActual + (incrementoPotencia / 20);
    }

    public int PotenciaMaxima
    {
        get {  return _potenciaMaxima; }
        private set
        {
            if (value < 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(PotenciaMaxima), "La potencia del motor debe ser minimo de 1000 voltios");
            }
            _potenciaMaxima = value;
        }   
    }

    public int TemperaturaActual
    {
        get { return _temperaturaActual; }
        private set
        {
            _temperaturaActual = value;
        }
    }

    public bool MotorEncendido
    {
        get { return _motorEncendido; }
        private set
        {
            _motorEncendido = value;
        }
    }
}
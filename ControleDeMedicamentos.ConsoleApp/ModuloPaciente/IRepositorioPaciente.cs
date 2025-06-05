﻿using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public interface IRepositorioPaciente : IRepositorio<Paciente>  {
    bool CartaoSusDuplicado(Paciente paciente);
}
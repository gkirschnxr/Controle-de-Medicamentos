﻿using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

public interface IRepositorioFuncionario : IRepositorio<Funcionario> {
    bool CpfEstaDuplicado(Funcionario funcionario);
}
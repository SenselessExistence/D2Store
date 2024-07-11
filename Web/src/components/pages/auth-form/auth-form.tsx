import React, { useEffect, useState } from 'react';
import './auth-form.scss';
import { FormProvider, SubmitHandler, useForm } from 'react-hook-form';
import Input from '../../fields/input/input';
import { useLocation, useNavigate } from 'react-router-dom';
import { AuthFormType } from '../../../enum/auth-form.type';
import { FormValues } from '../../../types/form-values.type';
import useAuthorization from '../../../hooks/apihooks/authorization.hook';
import { useToken } from '../../../context/auth-context';


const AuthForm = () => {
  const methods = useForm<FormValues>();
  const {reset} = methods;
  const location = useLocation();
  const navigate = useNavigate();
  const [type, setType] = useState<AuthFormType>(AuthFormType.None);
  const {register, login} = useAuthorization();
  const {setToken} = useToken();

  useEffect(() => {
    if (location.pathname.includes('/login')) {
      setType(AuthFormType.Login);
    } else if (location.pathname.includes('/registration')) {
      setType(AuthFormType.Registration);
    }
    reset();
  },[location.pathname, reset]);

  const onSubmit: SubmitHandler<FormValues> = data => {
    if (type === AuthFormType.Login) {
      login(data).then(token => {
        if (setToken)
          setToken(token);
        navigate('/');
      });
    } else if (type === AuthFormType.Registration) {
      register(data);
    }
  }
  

  return (
    <div className='form-layout'>
      <FormProvider {...methods}>
      <form className='auth-form'onSubmit={methods.handleSubmit(onSubmit)}>
        { type === AuthFormType.Registration &&
        <Input
          type="text"
          placeholder="Nickname"
          isRequired={true}
          maxLength={20}
          name='nickname'
          />
        }
        <Input
          type='email'
          placeholder="Email"
          isRequired={true}
          name='email'
          pattern={/^\S+@\S+$/i}
          />
        <Input
          type='password'
          placeholder="Password"
          isRequired={true}
          name='password'
          />
        { type === AuthFormType.Registration &&
        <Input
          type='password'
          placeholder="Confirm password"
          isRequired={true}
          name='confirmPassword'
          />
        }
      <button type="submit">Submit</button>
    </form>
    </FormProvider>
    </div>
  );
}

export default AuthForm;

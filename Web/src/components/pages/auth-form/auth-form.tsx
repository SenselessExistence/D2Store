import React from 'react';
import './auth-form.scss';
import { FormProvider, SubmitHandler, useForm } from 'react-hook-form';
import Input from '../../fields/input/input';

type FormValues = {
  nickname: string;
  email: string;
  password: string;
  confirmPassword: string;
};

const AuthForm = () => {
  const methods = useForm<FormValues>();

  const onSubmit: SubmitHandler<FormValues> = data => console.log(data);
  

  return (
    <div className='form-layout'>
      <FormProvider {...methods}>
      <form className='auth-form'onSubmit={methods.handleSubmit(onSubmit)}>
        <Input
          type="text"
          placeholder="Nickname"
          isRequired={true}
          maxLength={20}
          name='nickname'
          />
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
        <Input
          type='password'
          placeholder="Confirm password"
          isRequired={true}
          name='confirmPassword'
          />

      <button type="submit">Submit</button>
    </form>
    </FormProvider>
    </div>
  );
}

export default AuthForm;

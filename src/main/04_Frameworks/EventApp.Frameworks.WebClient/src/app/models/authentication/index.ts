export type AuthenticationSetState = {
    isAuthenticated: true;
    userId: string;
  }
  
  export type AuthenticationClearedState = {
    isAuthenticated: false;
  }
  
  export type AuthenticationState = AuthenticationClearedState | AuthenticationSetState;

export const STATE_AUTHENTICATION_CLEARED: AuthenticationClearedState = {
    isAuthenticated: false
} 